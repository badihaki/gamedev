using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attack;
    public int speed;
    public int jump;

    #region Components
    public Animator Anim { get; private set; }
    public PlayerControls Controls { get; private set; }
    public PlayerMoveController MoveController { get; private set; }
    private CapsuleCollider2D boundary;
    #endregion

    #region state machine
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        if (GetComponent<Animator>() != null)
        {
            Anim = GetComponent<Animator>();
        }
        
        if (GetComponent<PlayerControls>() != null)
        {
            Controls = GetComponent<PlayerControls>();
        }

        if (GetComponent<PlayerMoveController>() != null)
        {
            MoveController = GetComponent<PlayerMoveController>();
            MoveController.InitController();
        }
        if (GetComponent<CapsuleCollider2D>() != null)
        {
            boundary = GetComponent<CapsuleCollider2D>();
        }

        InitializePlayerState();
        StateMachine.Initialize(IdleState);
    }
    public void InitializePlayerState()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, "move");
        JumpState = new PlayerJumpState(this, StateMachine, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, "inAir");
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

    #region Grounded
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float extraHeightDistance;
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
    #endregion

    // end of the line
}
