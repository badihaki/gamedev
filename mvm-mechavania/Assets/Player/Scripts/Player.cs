using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    public int attack;
    public float speed;
    public int jump;
    public Interactor CurrentInteractableObj { get; private set; }
    public void GetNewInteractiveObj(Interactor newObj)
    {
        CurrentInteractableObj = newObj;
    }
    public void UseInteractableObj()
    {
        CurrentInteractableObj.SetInteract(this);
    }
    public void RemoveInteractiveObj()
    {
        CurrentInteractableObj = null;
    }

    //
    // Components
    #region Components
    public Health Health { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerControls Controls { get; private set; }
    public PlayerMoveController MoveController { get; private set; }
    public PlayerAttackController AttackController { get; private set; }
    private CapsuleCollider2D boundary;
    public Activator Activator { get; private set; }
    public PlayerAbilities AbilityUnlocks { get; private set; }
    private CinemachineVirtualCamera _CamController;
    #endregion

    //
    // State Machine
    #region state machine
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerMechState MechState { get; private set; }
    public PlayerLeaveMechState LeaveMechState { get; private set; }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        Anim = GetComponent<Animator>();
        
        Controls = GetComponent<PlayerControls>();

        MoveController = GetComponent<PlayerMoveController>();
        MoveController.InitController();
        boundary = GetComponentInChildren<CapsuleCollider2D>();
        Activator = GetComponentInChildren<Activator>();
        AttackController = GetComponent<PlayerAttackController>();
        AbilityUnlocks = GetComponent<PlayerAbilities>();
        _CamController = GameObject.Find("Cam-Player").GetComponent<CinemachineVirtualCamera>();

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
        MechState = new PlayerMechState(this, StateMachine, "mech");
        LeaveMechState = new PlayerLeaveMechState(this, StateMachine, "inAir");
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

    public void SetPlayerCam()
    {
        _CamController.Priority = 10;
    }
    public void SetMechCam()
    {
        _CamController.Priority = 8;
    }

    public void Damage(int dmg, int direction, Vector2 pushBack)
    {
        
    }
    // end of the line
}
