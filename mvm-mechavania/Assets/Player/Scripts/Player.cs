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
    public PlayerControls InputController { get; private set; }
    public PlayerMoveController MoveController { get; private set; }
    #endregion

    #region state machine
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
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
            InputController = GetComponent<PlayerControls>();
        }

        if (GetComponent<PlayerMoveController>() != null)
        {
            MoveController = GetComponent<PlayerMoveController>();
            MoveController.InitController();
        }

        InitializePlayerState();
        StateMachine.Initialize(IdleState);
    }
    public void InitializePlayerState()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, "move");
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
}
