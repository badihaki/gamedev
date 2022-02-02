using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechUnoccupiedIdleState : MechState
{
    public MechUnoccupiedIdleState(MechProperties theMech, MechStateMachine theStateMachine, Mecha theData, string theAnimBoolName) : base(theMech, theStateMachine, theData, theAnimBoolName)
    {
    }

}
