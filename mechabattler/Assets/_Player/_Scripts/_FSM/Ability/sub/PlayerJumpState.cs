using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }
    protected int xInput;
    protected bool attackButton;

    public override void Enter()
    {
        base.Enter();
        player.MoveController.Jump();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.player.Controls.XInput;
        attackButton = player.player.Controls.FireButton;

        // follow the mouse aim
        player.WeaponController.FollowAim();
        // attack with weapon (shoot)
        if (attackButton == true)
        {
            player.WeaponController.FireWeapon();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        // make sure we can move whilest jumping
        player.MoveController.MovePlayerX(xInput);
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time > startTime + 0.35f)
        {
            if (!isGrounded)
            {
                // not grounded, go to freefall
                stateMachine.ChangeState(player.FreeFallState);
            }
            else
            {
                // grounded, go to land state
                stateMachine.ChangeState(player.FreeFallLandingState);
            }
        }
    }
}
