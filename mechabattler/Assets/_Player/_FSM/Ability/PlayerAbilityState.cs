using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    public PlayerAbilityState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

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
