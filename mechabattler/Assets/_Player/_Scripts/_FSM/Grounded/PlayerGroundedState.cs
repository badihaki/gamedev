using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    protected int xInput;
    protected int yInput;
    protected bool attackButton;
    protected bool jumpButton;
    protected bool interactButton;

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.player.Controls.XInput;
        yInput = player.player.Controls.YInput;
        attackButton = player.player.Controls.FireButton;
        jumpButton = player.player.Controls.JumpButton;
        interactButton = player.player.Controls.InteractButton;

        // follow the mouse aim
        player.WeaponController.FollowAim();
        // attack with weapon (shoot)
        if (attackButton == true)
        {
            player.WeaponController.FireWeapon();
        }
        // interaction
        if (interactButton == true)
        {
            player.InteractionController.InteractWith();
        }
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (isGrounded)
        {
            // jump from ANY grounded state at ANY time
            if (jumpButton)
            {
                player.player.Controls.UseJump();
                if (player.MoveController.jumpCount > 0)
                {
                    // can jump, will jump
                    stateMachine.ChangeState(player.JumpState);
                }
            }
        }
        else if (!isGrounded)
        {
            // transition to freefall
            player.FreeFallState.StartCoyoteTime();
            stateMachine.ChangeState(player.FreeFallState);
        }
    }
}
