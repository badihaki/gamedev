using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPilotEjectState : MechState
{
    public MechPilotEjectState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName) : base(theMecha, theStateMachine, theAnimBoolName)
    {
    }
}
