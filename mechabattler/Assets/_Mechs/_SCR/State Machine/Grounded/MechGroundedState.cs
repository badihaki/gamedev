using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechGroundedState : MechState
{

    protected int xInput;
    protected int yInput;
    protected bool attackButton;
    protected bool jumpButton;
    protected bool interactButton;

    public MechGroundedState(MechProperties theMech, MechStateMachine theStateMachine, Mecha theData, string theAnimBoolName) : base(theMech, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        mech.PilotSticky();

        xInput = mech.Controls.XInput;
        yInput = mech.Controls.YInput;
        attackButton = mech.Controls.FireButton;
        jumpButton = mech.Controls.JumpButton; // may not need this, lets see!!
        interactButton = mech.Controls.InteractButton;
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        // if we are in the grounded state, we can disembark
        if (interactButton)
        {
            stateMachine.ChangeState(mech.DisembarkState);
        }
    }
}
