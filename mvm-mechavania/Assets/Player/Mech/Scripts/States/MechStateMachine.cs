using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStateMachine
{
    public MechState CurrentState { get; private set; }

    public void Initialize(MechState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
    public void ChangeState(MechState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
