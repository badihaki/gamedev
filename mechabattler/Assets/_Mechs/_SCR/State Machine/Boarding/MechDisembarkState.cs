using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDisembarkState : MechBoardingState
{
    public MechDisembarkState(MechProperties theMech, MechStateMachine theStateMachine, Mecha theData, string theAnimBoolName) : base(theMech, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // we need to give the player their rigidbody back
        mech.NoMorePilot();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time > startTime + 0.5f)
        {
            stateMachine.ChangeState(mech.UnoccupiedIdleState);
        }
    }
}
