using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMoveState : MechGroundedState
{
    public MechMoveState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName) : base(theMecha, theStateMachine, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        mecha.MoveController.Move(mecha.Pilot.Controls.Xinput);
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if(mecha.Pilot.Controls.Xinput == 0)
        {
            stateMachine.ChangeState(mecha.IdleState);
        }
    }
}
