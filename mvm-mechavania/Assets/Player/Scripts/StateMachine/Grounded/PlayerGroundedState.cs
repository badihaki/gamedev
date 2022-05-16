using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player thePlayer, PlayerStateMachine theStateMachine, string theAnimBoolName) : base(thePlayer, theStateMachine, theAnimBoolName)
    {
    }

    protected int xInput;
    protected bool jumpInput;
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputInterface.Xinput;
        jumpInput = player.InputInterface.JumpButton;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
