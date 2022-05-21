using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeaveMechState : PlayerState
{
    public PlayerLeaveMechState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.Activator.gameObject.SetActive(true);
        player.SetPlayerCam();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time >= startTime + 0.5f)
            stateMachine.ChangeState(player.InAirState);
    }
}
