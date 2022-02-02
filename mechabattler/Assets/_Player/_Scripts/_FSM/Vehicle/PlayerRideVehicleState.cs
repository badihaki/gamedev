using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRideVehicleState : PlayerVehicleState
{
    public PlayerRideVehicleState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

}
