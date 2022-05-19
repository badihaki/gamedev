using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechState
{
    protected Mech mecha;
    protected MechStateMachine stateMachine;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;

    protected bool isGrounded;

    public MechState(Mech theMecha, MechStateMachine theStateMachine, string theAnimBoolName)
    {
        this.mecha = theMecha;
        this.stateMachine = theStateMachine;
        this.animBoolName = theAnimBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        mecha.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }
    public virtual void Exit()
    {
        mecha.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }
    public virtual void LogicUpdate()
    {
        /*
         * This function occured on the UPDATE timecycle. Just regular UPDATE
         * so it'll occue once per frame.
         * 
         * Use this function to control the logic to move from one state to another,
         * as well as changing variables
         */
        isGrounded = mecha.Grounded();

        if (!isExitingState)
        {
            TransitionConditions();
        }
    }
    public virtual void PhysicsUpdate()
    {
        /*
         * This function occurs on the FIXED UPDATE timecycle.
         * It controls PC physics, of course. The physics will be
         * controlled by changes in variables
         */

        DoChecks();
    }
    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void TransitionConditions()
    {

    }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
