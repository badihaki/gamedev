using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Anim { get; private set; }
    public PlayerControls InputInterface { get; private set; }

    #region state machine
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializePlayerState()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, "idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
