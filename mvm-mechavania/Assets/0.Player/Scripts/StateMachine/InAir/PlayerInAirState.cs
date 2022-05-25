using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    public PlayerInAirState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName)
    {
    }

    protected int xInput;
    protected bool jumpInput;
    // protected bool attackButton;

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.Controls.Xinput;
        jumpInput = player.Controls.JumpButton;
        isGrounded = player.Grounded();
        //attackButton = player.Controls.FireButton;

        player.MoveController.Move(xInput);
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
