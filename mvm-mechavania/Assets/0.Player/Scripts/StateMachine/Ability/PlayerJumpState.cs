using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName)
    {
    }
    protected int xInput;
    protected bool attackInput;

    public override void Enter()
    {
        base.Enter();
        player.MoveController.Jump();
        Debug.Log("Jumpin");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.Controls.Xinput;
        // attackButton = player.Controls.FireButton;
        player.MoveController.Move(xInput);
        Attack();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        // make sure we can move whilest jumping
    }

    private void Attack()
    {
        if (attackInput)
        {
            // attack
            player.AttackController.Attack();
        }
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time > startTime + 0.35f)
        {
            if (!isGrounded)
            {
                // not grounded, go to freefall
                stateMachine.ChangeState(player.InAirState);
            }
            else
            {
                // grounded, go to land state
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
