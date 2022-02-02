using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechProperties : MonoBehaviour
{
    public Mecha mech;
    public PCProperties pilot;

    #region misc var
    [SerializeField] private LayerMask groundLayers;
    #endregion

    #region components
    // public MechControls Controls { get; private set; }
    public PlayerInputInterface Controls { get; private set; }

    public Animator Anim { get; private set; }
    public BoxCollider2D Boundary { get; private set; }
    public MechMoveController MoveController { get; private set; }
    // get the interaction gameobj to enable and disable it
    private GameObject interax;
    [SerializeField] private Transform cockpit;
    #endregion

    #region state machine
    public MechStateMachine StateMachine { get; private set; }
    public MechUnoccupiedIdleState UnoccupiedIdleState { get; private set; }
    public MechOccupiedIdleState IdleState { get; private set; }
    public MechMoveState MoveState { get; private set; }
    public MechEmbarkState EmbarkState { get; private set; }
    public MechDisembarkState DisembarkState { get; private set; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // initialize gameplay
        //initialize Statemachine
        InitGameplay();
        InitStateMachine();
    }

    private void InitGameplay()
    {
        if (GetComponent<Animator>() != null)
        {
            Anim = GetComponent<Animator>();
        }
        Boundary = transform.Find("Body").GetComponent<BoxCollider2D>();
        interax = transform.Find("Mecha Interact").gameObject;
        cockpit = transform.Find("Cockpit");

        MoveController = GetComponent<MechMoveController>();
    }

    private void InitStateMachine()
    {
        StateMachine = new MechStateMachine();

        // These states are initiated regardless, and stay consistent through
        // this gameobject's lifetime
        UnoccupiedIdleState = new MechUnoccupiedIdleState(this, StateMachine, mech, "idleNoPilot");
        EmbarkState = new MechEmbarkState(this, StateMachine, mech, "embark");
        DisembarkState = new MechDisembarkState(this, StateMachine, mech, "disembark");

        if (pilot != null)
        {
            // has pilot, start in pilotidle state
            StateMachine.Initialize(IdleState);
        }
        else
        {
            // no pilot, start in unoccupiedidle state
            StateMachine.Initialize(UnoccupiedIdleState);
        }
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #region Checker Funct
    public bool Grounded()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(Boundary.bounds.center, Boundary.bounds.size, 0.0f, Vector2.down, groundLayers);

        Color rayColor;

        if (rayHit.collider != null) // if we have something below us
            rayColor = Color.cyan;
        else // we aren't hitting shit
            rayColor = Color.red;

        Debug.DrawRay(Boundary.bounds.center + new Vector3(Boundary.bounds.extents.x, 0), Vector2.down * (Boundary.bounds.extents.y), rayColor);
        Debug.DrawRay(Boundary.bounds.center - new Vector3(Boundary.bounds.extents.x, 0), Vector2.down * (Boundary.bounds.extents.y), rayColor);
        Debug.DrawRay(Boundary.bounds.center - new Vector3(Boundary.bounds.extents.x, Boundary.bounds.extents.y), Vector2.right * (Boundary.bounds.extents.x), rayColor);
        return rayHit.collider != null;
    }
    #endregion

    #region mech specific functs
    public void GetNewPilot(PCProperties newpilot)
    {
        pilot = newpilot;
        print("new pilot = " + pilot);
        Controls = pilot.player.Controls;
        print("controls are here: " + Controls);
        // we got a new pilot so we can disable interaction
        interax.SetActive(false);
        pilot.StateMachine.ChangeState(pilot.BoardVehicleState);
        StateMachine.ChangeState(EmbarkState);
        // load pilot control'd states below
        LoadPilotRequiredStates();
    }
    public void NoMorePilot()
    {
        pilot.MoveController.PhysicsController.AddForce(new Vector2(UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-3, 3)), ForceMode2D.Impulse);
        pilot.StateMachine.ChangeState(pilot.DisembarkState);
        Controls = null;
        pilot = null;
        // unload pilot control'd states below
        UnloadPilotRequiredStates();
        // we need a pilot so interaction is ok
        interax.SetActive(true);
    }
    public void PilotSticky()
    {
        pilot.transform.position = cockpit.position;
    }

    private void LoadPilotRequiredStates()
    {
        // here I initialize the states that require a player character
        IdleState = new MechOccupiedIdleState(this, StateMachine, mech, "idle");
        MoveState = new MechMoveState(this, StateMachine, mech, "move");
    }
    private void UnloadPilotRequiredStates()
    {
        // The inverse of the prior function, this function unloads the states that require a pilot
        // here I initialize the states that require a player character
        IdleState = null;
        MoveState = null;
    }
    #endregion
}
