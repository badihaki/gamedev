using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMoveState : MechGroundedState
{
    public MechMoveState(MechProperties theMech, MechStateMachine theStateMachine, Mecha theData, string theAnimBoolName) : base(theMech, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        mech.MoveController.MoveX(xInput);
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (xInput == 0)
        {
            stateMachine.ChangeState(mech.IdleState);
        }
    }
}
