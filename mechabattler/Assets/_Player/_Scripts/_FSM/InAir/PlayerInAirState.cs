using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    public PlayerInAirState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    protected int xInput;
    protected bool jumpInput;
    protected bool attackButton;

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.player.Controls.XInput;
        jumpInput = player.player.Controls.JumpButton;
        attackButton = player.player.Controls.FireButton;

        // follow the mouse aim
        player.WeaponController.FollowAim();
        // attack with weapon (shoot)
        if (attackButton == true)
        {
            player.WeaponController.FireWeapon();
        }
    }
    public override void DoChecks()
    {
        base.DoChecks();
    }
}
