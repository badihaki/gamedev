using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBoardingState : MechState
{
    public MechBoardingState(MechProperties theMech, MechStateMachine theStateMachine, Mecha theData, string theAnimBoolName) : base(theMech, theStateMachine, theData, theAnimBoolName)
    {
    }
}
