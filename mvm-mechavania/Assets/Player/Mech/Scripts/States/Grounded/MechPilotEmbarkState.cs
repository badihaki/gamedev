using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPilotEmbarkState : MechState
{
    public MechPilotEmbarkState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName) : base(theMecha, theStateMachine, theAnimBoolName)
    {
    }
}
