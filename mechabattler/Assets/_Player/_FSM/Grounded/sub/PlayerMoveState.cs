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

        player.MoveController.MovePlayer(xInput);
    }

    public override void TransitionConditions()
    {
        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }
}
