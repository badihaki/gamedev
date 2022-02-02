using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoardVehicleState : PlayerVehicleState
{
    public PlayerBoardVehicleState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        // lets turn off rigidbody physics
        player.MoveController.PhysicsController.isKinematic = true;
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time > startTime + 0.5f)
        {
            stateMachine.ChangeState(player.RideVehicleState);
        }
    }
}
