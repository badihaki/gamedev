using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.MoveController.MovePlayerX(xInput);
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }
}
