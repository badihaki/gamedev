using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechIdleState : MechGroundedState
{
    public MechIdleState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName) : base(theMecha, theStateMachine, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (mecha.Pilot.Controls.Xinput != 0)
        {
            stateMachine.ChangeState(mecha.MoveState);
        }
    }

    // end 
}
