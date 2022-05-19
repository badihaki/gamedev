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
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();
    }
}
