using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;

    protected bool isGrounded;

    protected Transform target;

    public EnemyState(Enemy theEnemy, EnemyStateMachine theStateMachine, string theAnimBoolName)
    {
        this.enemy = theEnemy;
        this.stateMachine = theStateMachine;
        this.animBoolName = theAnimBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        enemy.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log("ENEMY entering state: " + stateMachine.CurrentState + " animator value: " + animBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }
    public virtual void Exit()
    {
        isExitingState = true;
        enemy.Anim.SetBool(animBoolName, false);
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
        isGrounded = enemy.Grounded();
        target = enemy.Target.Target;

        if (!isExitingState)
        {
            TransitionConditions();
            // Debug.Log("current state: " + this);
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
