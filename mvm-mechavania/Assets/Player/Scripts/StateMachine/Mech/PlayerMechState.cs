using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechState : PlayerState
{
    public PlayerMechState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.GetComponentInChildren<Activator>().gameObject.SetActive(false);
    }
}
