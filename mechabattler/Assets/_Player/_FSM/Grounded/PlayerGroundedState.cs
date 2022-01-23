using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PCProperties thePlayer, PlayerFiniteStateMachine theStateMachine, PlayerCharacter theData, string theAnimBoolName) : base(thePlayer, theStateMachine, theData, theAnimBoolName)
    {
    }

    protected int xInput;
    protected int yInput;
    protected bool attackButton;
    protected bool isGrounded;

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.player.Controls.XInput;
        yInput = player.player.Controls.YInput;
        attackButton = player.player.Controls.FireButton;

        // follow the mouse aim
        player.WeaponController.FollowAim();
        // attack with weapon (shoot)
        if (attackButton == true)
        {
            player.WeaponController.FireWeapon();
        }
    }
}
