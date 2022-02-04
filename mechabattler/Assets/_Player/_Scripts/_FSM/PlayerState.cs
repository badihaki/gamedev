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

    /// <summary>
    /// player obj
    /// </summary>
    protected PCProperties player; // we will access the player to change states and access certain in-game values
    protected PlayerFiniteStateMachine stateMachine;
    protected PlayerCharacter playerData; // we will access PlayerCharacter as data to carry stuff like stats

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;

    protected bool isGrounded;


    #region Hit Attributes
    protected bool hurt;
    protected bool hitNorm;
    protected bool hitLow;
    protected bool hitOverhead;
    protected bool hitKnockdown;
    protected bool hitKnockback;
    #endregion

    public PlayerState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName)
    {
        this.player = thePlayer;
        this.stateMachine = theStateMachine;
        this.playerData = theData;
        this.animBoolName = theAnimBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        // Debug.Log("entering state: " + stateMachine.CurrentState + " /// animator value: " + animBoolName);
        UpdateUI();
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

        // make sure grounded is hooked up all the time
        // FOREVER CHECK FOR GROUNDED WHY ARENT WE CHECKING FOR GROUNDED!?
        isGrounded = player.Grounded();
        // if we aren't already exiting the state, check for transition conditions
        if (!isExitingState)
        {
            TransitionConditions();
        }


        /*
         * hurt logic below
        hurt = player.HurtController.Hurt;
        hitNorm = player.HurtController.HitNorm;
        hitLow = player.HurtController.HitLow;
        hitOverhead = player.HurtController.HitOverhead;
        hitKnockdown = player.HurtController.HitKnockdown;
        hitKnockback = player.HurtController.HitKnockback;
        */
    }
    /// <summary>
    /// This controls the state's conditions for transitioning to another state
    /// To be overwritten in EVERY individual state
    /// </summary>
    public virtual void TransitionConditions()
    {
        
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
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

    void UpdateUI()
    {
        player.UI.UpdateStateUI(animBoolName);
    }

}
