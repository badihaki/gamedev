using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyGroundedState
{
    public EnemyIdleState(Enemy theEnemy, EnemyStateMachine theStateMachine, string theAnimBoolName) : base(theEnemy, theStateMachine, theAnimBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //enemy.MoveController.ZeroVelocityX();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();


        if (enemy.Target.Target != null)
        {
            stateMachine.ChangeState(enemy.ChaseState);
        }
    }
}
