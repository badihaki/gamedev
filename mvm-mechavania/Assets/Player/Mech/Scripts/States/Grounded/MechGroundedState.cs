using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechGroundedState : MechState
{    public MechGroundedState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName) : base(theMecha, theStateMachine, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
            mecha.StickyPilot();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (Time.time >= startTime + 1)
        {
            if (mecha.Pilot.Controls.Yinput == -1 && mecha.Pilot.Controls.InteractButton)
            {
                stateMachine.ChangeState(mecha.MechPilotEjectState);
            }
        }
    }
}
