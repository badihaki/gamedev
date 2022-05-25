using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName)
    {
    }

    protected int xInput;
    protected bool jumpInput;
    protected bool attackInput;
    protected bool interactInput;

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.Controls.Xinput;
        jumpInput = player.Controls.JumpButton;
        attackInput = player.Controls.AttackButton;
        interactInput = player.Controls.InteractButton;

        Attack();
        Interact();
    }

    private void Attack()
    {
        if (attackInput)
        {
            // attack
            player.AttackController.Attack();
        }
    }

    private void Interact()
    {
        if (interactInput && player.CurrentInteractableObj != null)
        {
            player.UseInteractableObj();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (isGrounded)
        {
            if (jumpInput)
            {
            player.Controls.UseJump();
            stateMachine.ChangeState(player.JumpState);
            }
        }
        else
        {
            stateMachine.ChangeState(player.InAirState);
        }

    }
}
