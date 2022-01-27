using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeFallState : PlayerInAirState
{
    public PlayerFreeFallState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // make sure we can go left or right while freefalling
        // air control is important
        player.MoveController.MovePlayerX(xInput);

        // always check for Coyote Time
        // It checks both the boolean and the time
        CheckCoyoteTime();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (jumpInput)
        {
            player.player.Controls.UseJump();
            if (player.MoveController.jumpCount > 0)
            {
                // can jump, will jump
                stateMachine.ChangeState(player.JumpState);
            }
        }
        
        if (isGrounded)
        {
            // grounded, transition to freefall landing state
            stateMachine.ChangeState(player.FreeFallLandingState);
        }
    }
    
    /*
     Coyote Time is named after Wiley-E Coyote of Looney Tunes fame
     He would often go over a cliff and have a moment to react, often humorously
     we wanna mimick that, but the reaction we're looking for from the player
     is a jump
    */
    public bool coyoteTime { get; private set; }
    private void CheckCoyoteTime()
    {
        if (coyoteTime == true && Time.time > startTime + 0.20f) // coyote time is set here, its the start time + float
        {
            player.MoveController.SetCoyoteJumpCount();
            coyoteTime = false;
            Debug.LogWarning("coyote time...disengaged");
        }
    }
    public void StartCoyoteTime()
    {
        coyoteTime = true;
        Debug.LogWarning("coyote time engaging");
    }
}
