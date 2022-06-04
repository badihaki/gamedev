using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCinemaState : PlayerState
{
    public PlayerCinemaState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName)
    {
    }

    bool attackButton;
    bool jumpButton;
    GM gameMaster;
    
    public override void Enter()
    {
        base.Enter();

        gameMaster = GameObject.Find("Game Master").GetComponent<GM>();
        player.MoveController.Move(0);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        attackButton = player.Controls.AttackButton;
        jumpButton = player.Controls.JumpButton;

        if (Time.time > startTime + 1.00f)
        {
            if(attackButton || jumpButton)
            {
                player.Controls.UseCinemaButton();
                gameMaster.DialogueManager.StartNextDialogue();
                startTime = Time.time;
            }
        }
    }

}
