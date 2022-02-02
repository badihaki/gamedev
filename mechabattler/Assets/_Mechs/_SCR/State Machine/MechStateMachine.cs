using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStateMachine
{/*
     * <<<<<<<<<<<--------------STATE MACHINE DOC
     *
     *  This is the class the controls the states.
     *  
     *  We can use this class to change from one state to another.
     * 
     */

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
