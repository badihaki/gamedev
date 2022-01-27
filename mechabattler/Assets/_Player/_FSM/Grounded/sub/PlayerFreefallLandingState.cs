using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreefallLandingState : PlayerGroundedState
{
    public PlayerFreefallLandingState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        /*
         * When animation is in, THIS finishes the state
         * and send the player back to idle
         */

        stateMachine.ChangeState(player.IdleState);
    }

    public override void Enter()
    {
        base.Enter();
        /*
         * When entering this state, we spawn a plume of smoke
         * we also must reset our jump count
         */
        player.MoveController.MovePlayerX(0);
        player.MoveController.ResetJumpCount();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time > startTime + 0.5f)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
