using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    public PlayerAbilityState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName) { }

    protected bool isAbilityFinished; // This is used to track when the ability is finished
    // for certain actions and transitions

    public override void Enter()
    {
        base.Enter();
        isAbilityFinished = false;
    }

    public override void Exit()
    {
        base.Exit();
        if (isAbilityFinished != true)
            isAbilityFinished = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();
    }
}
