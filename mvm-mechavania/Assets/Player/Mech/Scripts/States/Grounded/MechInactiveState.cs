using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechInactiveState : MechState
{
    public MechInactiveState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName) : base(theMecha, theStateMachine, theAnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (mecha.Pilot != null)
        {
            mecha.EjectPilot();
        }
    }
}
