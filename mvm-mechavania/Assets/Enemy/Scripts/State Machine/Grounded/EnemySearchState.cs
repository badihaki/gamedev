using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : EnemyGroundedState
{
    public EnemySearchState(Enemy theEnemy, EnemyStateMachine theStateMachine, string theAnimBoolName) : base(theEnemy, theStateMachine, theAnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.MoveController.ZeroVelocityX();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isExitingState)
            if (Time.time > startTime + 0.65f)
                {
                    Searching();
                }

    }

    private void Searching()
    {
        enemy.Target.RunTimer();

        if (enemy.MoveController.FacingRight)
            enemy.MoveController.Move(1, 0.35f);
        else
            enemy.MoveController.Move(-1, 0.35f);
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (enemy.Target.TargetTimer <= 0)
            stateMachine.ChangeState(enemy.IdleState);
        if (enemy.Target.Target != null)
        {
            stateMachine.ChangeState(enemy.ChaseState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        enemy.Target.ResetTargetComponent();
    }

    // end
}
