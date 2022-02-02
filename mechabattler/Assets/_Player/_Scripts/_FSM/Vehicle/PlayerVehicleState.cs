using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVehicleState : PlayerState
{
    public PlayerVehicleState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

}
