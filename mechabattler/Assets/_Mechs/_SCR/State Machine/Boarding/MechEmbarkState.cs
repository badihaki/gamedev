using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechEmbarkState : MechBoardingState
{
    public MechEmbarkState(MechProperties theMech, MechStateMachine theStateMachine, Mecha theData, string theAnimBoolName) : base(theMech, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time > startTime + 0.5f)
        {
            stateMachine.ChangeState(mech.IdleState);
        }
    }
}
