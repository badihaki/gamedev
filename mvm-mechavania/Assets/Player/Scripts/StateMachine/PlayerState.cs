using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    /*
 * <<<<<<<<<<<--------------STATE MACHINE DOC
 * 
 * This is the overarchine state script that all other states will inherit from.
 * 
 * THIS IS NOT A MONOBEHAVIOUR, and cannot be added to an ingame player character's
 * gameobject. It can only be accessed via script, by the PCActor class.
 * 
 * This will contain all the base functions a state would need to operate.
 * The states then override the base functions, keeping their functionality while
 * simultaneoulsy running their own logic right after.
 * 
 * ALL STATES INHERIT FROM THIS CLASS
 * 
 */


    protected Player player;
    protected PlayerStateMachine stateMachine;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;

    protected bool isGrounded;

    public PlayerState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName)
    {
        this.player = thePlayer;
        this.stateMachine = theStateMachine;
        this.animBoolName = theAnimBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log("entering state: " + stateMachine.CurrentState + " animator value: " + animBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
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
        isGrounded = player.Grounded();

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
