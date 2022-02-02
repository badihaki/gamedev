using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisembarkState : PlayerVehicleState
{
    public PlayerDisembarkState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void Exit()
    {
        base.Exit();
        player.MoveController.PhysicsController.isKinematic = false;
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
