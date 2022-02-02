using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechOccupiedIdleState : MechGroundedState
{
    public MechOccupiedIdleState(MechProperties theMech, MechStateMachine theStateMachine, Mecha theData, string theAnimBoolName) : base(theMech, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (xInput != 0)
        {
            stateMachine.ChangeState(mech.MoveState);
        }
    }

}
