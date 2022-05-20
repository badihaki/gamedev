using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{
    public int attack;
    public int speed;
    public int jump;

    #region Components
    public Animator Anim { get; private set; }
    // public PlayerMoveController MoveController { get; private set; }
    [SerializeField] private BoxCollider2D boundary;
    public Player Pilot { get; private set; }
    [SerializeField] private Transform cockpit;
    public Interactor Interactor { get; private set; }
    #endregion

    #region state machine
    public MechStateMachine StateMachine { get; private set; }
    public MechInactiveState MechInactiveState { get; private set; }
    public MechPilotEmbarkState MechPilotEmbarkState { get; private set; }
    public MechPilotEjectState MechPilotEjectState { get; private set; }
    public MechIdleState IdleState { get; private set; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        boundary = GetComponentInChildren<BoxCollider2D>();
        Interactor = GetComponentInChildren<Interactor>();

        StateMachine = new MechStateMachine();
        MechInactiveState = new MechInactiveState(this, StateMachine, "idle");

        StateMachine.Initialize(MechInactiveState);
    }
    #region Pilot Functs
    public void GetPilot(Player newPilot)
    {
        Pilot = newPilot;

        IdleState = new MechIdleState(this, StateMachine, "idle");
        MechPilotEmbarkState = new MechPilotEmbarkState(this, StateMachine, "idle");
        MechPilotEjectState = new MechPilotEjectState(this, StateMachine, "idle");

        StateMachine.ChangeState(MechPilotEmbarkState);
    }
    public void EjectPilot()
    {
        IdleState = null;
        MechPilotEmbarkState = null;
        MechPilotEjectState = null;
        Pilot.MoveController.Eject();

        Pilot = null;
    }
    public void StickyPilot()
    {
        Pilot.transform.position = cockpit.position;
    }
#endregion

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    [SerializeField] private float extraHeightDistance = 0;
    [SerializeField] private LayerMask groundLayers;
    public bool Grounded()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(boundary.bounds.center, boundary.bounds.size, 0.0f, Vector2.down, extraHeightDistance, groundLayers);

        Color rayColor;

        if (rayHit.collider != null) // if we have something below us
            rayColor = Color.cyan;
        else // we aren't hitting shit
            rayColor = Color.red;

        Debug.DrawRay(boundary.bounds.center + new Vector3(boundary.bounds.extents.x, 0), Vector2.down * (boundary.bounds.extents.y + extraHeightDistance), rayColor);
        Debug.DrawRay(boundary.bounds.center - new Vector3(boundary.bounds.extents.x, 0), Vector2.down * (boundary.bounds.extents.y + extraHeightDistance), rayColor);
        Debug.DrawRay(boundary.bounds.center - new Vector3(boundary.bounds.extents.x, boundary.bounds.extents.y + extraHeightDistance), Vector2.right * (boundary.bounds.extents.x), rayColor);
        return rayHit.collider != null;
    }
}
