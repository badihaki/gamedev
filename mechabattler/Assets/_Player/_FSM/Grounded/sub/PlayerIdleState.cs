using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (xInput != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }
}
