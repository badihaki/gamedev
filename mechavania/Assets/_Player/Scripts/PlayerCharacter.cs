using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerCharacter : MonoBehaviour
{
    // ~~~~ Components
    #region Components
    public PlayerMovement Movement { get; private set; }
    public PlayerInputInterface InputInterface { get; private set; }
    public Animator Anim { get; private set; }
    #endregion

    // State Machine
    #region State Machine
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    // Var
    #region Variables
    public float groundedRayDist = 0.25f;
    [SerializeField] private LayerMask whatIsGround;
    public bool Grounded()
    {
        // parameters
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, groundedRayDist, whatIsGround);
        Color rayColor;
        // 

        if (rayHit.collider != null) // if we have something below us
            rayColor = Color.cyan;
        else // we aren't hitting shit
            rayColor = Color.red;

        Debug.DrawRay(transform.position, Vector2.down * groundedRayDist, rayColor, 0.2f);
        return rayHit.collider != null;
    }
    #endregion

    // Player Stats
    #region Stats
    public int Health { get; private set; }
    public float Energy { get; private set; }
    public float Speed { get; private set; }
    #endregion

    #region unity callback functs
    // Awake is called before Start
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, "move");
    }

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        InputInterface = GetComponent<PlayerInputInterface>();

        StateMachine.Initialize(IdleState);
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
    #endregion

    #region checker functs
    #endregion
}
