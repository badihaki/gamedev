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
    private CapsuleCollider2D boundary;
    #endregion

    #region State Machine
    public PlayerFiniteStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFreeFallState FreeFallState { get; private set; }
    public PlayerFreefallLandingState FreeFallLandingState { get; private set; }
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

    }

    public void InitGameplay(PlayerObject plyr)
    {
        // set the player
        player = plyr;
        
        // set components
        Anim = GetComponent<Animator>();
        MoveController = GetComponent<PCLocomotion>();
        WeaponController = GetComponentInChildren<PCWeapon>();
        boundary = GetComponent<CapsuleCollider2D>();

        // lets start state machine after making sure components are good
        InitStateMachine();
    }
    public void InitStateMachine()
    {
        StateMachine = new PlayerFiniteStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, player.playerCharacter, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, player.playerCharacter, "move");
        JumpState = new PlayerJumpState(this, StateMachine, player.playerCharacter, "jump");
        FreeFallState = new PlayerFreeFallState(this, StateMachine, player.playerCharacter, "freefall");
        FreeFallLandingState = new PlayerFreefallLandingState(this, StateMachine, player.playerCharacter, "freefallLand");
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

    #region checker funtions
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
    #endregion
}
