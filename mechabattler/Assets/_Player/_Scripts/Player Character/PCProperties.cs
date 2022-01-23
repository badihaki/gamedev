using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The purpose of this script is to read the Player Obj Script for it's various variables
/// and link up to the player character's various controllers
/// </summary>
public class PCProperties : MonoBehaviour
{
    public PlayerObject player; // the player obj script to be referenced
    #region components
    public Animator Anim { get; private set; }
    public PCLocomotion MoveController { get; private set; } // movement script for moving and jumping, dawg
    public PCWeapon WeaponController { get; private set; }
    #endregion

    #region State Machine
    public PlayerFiniteStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    #endregion

    // awake called before start
    private void Awake()
    {
        /*
        StateMachine = new PlayerFiniteStateMachine();
        groundState = new PlayerGroundedState(player, StateMachine, player.playerCharacter, "idle");
        */
    }
    // Start is called before the first frame update
    void Start()
    {
        InitStateMachine();

    }

    public void InitGameplay(PlayerObject plyr)
    {
        // set the player
        player = plyr;
        // get animator
        Anim = GetComponent<Animator>();
        MoveController = GetComponent<PCLocomotion>();
        WeaponController = GetComponentInChildren<PCWeapon>();
    }
    public void InitStateMachine()
    {
        StateMachine = new PlayerFiniteStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, player.playerCharacter, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, player.playerCharacter, "move");
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
}
