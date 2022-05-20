using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPilotEmbarkState : MechState
{
    public MechPilotEmbarkState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName) : base(theMecha, theStateMachine, theAnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        mecha.Pilot.StateMachine.ChangeState(mecha.Pilot.MechState);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        mecha.StickyPilot();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if(Time.time > startTime + 0.5f)
        {
            stateMachine.ChangeState(mecha.IdleState);
        }
    }
}
