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
    [SerializeField] private int aim;

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
    private PlayerUI _PlayerUI;
    private CinemachineVirtualCamera _CamController;
    private FXHolder _FX;
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
    public PlayerCinemaState CinemaState { get; private set; }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
    }
    public void StartGame()
    {
        Health = GetComponent<Health>();
        Health.Initialize();
        // animator
        Anim = GetComponent<Animator>();
        // controls
        Controls = GetComponent<PlayerControls>();
        // movement
        MoveController = GetComponent<PlayerMoveController>();
        MoveController.InitController();
        // collider
        boundary = GetComponentInChildren<CapsuleCollider2D>();
        // actuvatir
        Activator = GetComponentInChildren<Activator>();
        Activator.Initialize();
        // attack
        AttackController = GetComponent<PlayerAttackController>();
        AttackController.Initialize();
        // abilities
        AbilityUnlocks = GetComponent<PlayerAbilities>();
        // camera
        _CamController = GameObject.Find("Cam-Player").GetComponent<CinemachineVirtualCamera>();
        // ui
        _PlayerUI = GetComponent<PlayerUI>();
        _PlayerUI.Initialize();
        // FX
        _FX = GetComponent<FXHolder>();


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
        CinemaState = new PlayerCinemaState(this, StateMachine, "cinema");
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        aim = Controls.Yinput;
        Anim.SetInteger("aim", aim);
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
        Health.TakeHealth(dmg);
        _PlayerUI.SyncHealthUI();
        Instantiate(_FX.hitEffect, transform.position, transform.rotation);
        Vector2 push = new Vector2(pushBack.x * direction, pushBack.y);
        MoveController.Bump(push);
    }
    // end of the line
}
