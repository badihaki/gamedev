using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntAttackState : EnemyAttackState
{
    public GruntAttackState(Enemy theEnemy, EnemyStateMachine theStateMachine, string theAnimBoolName) : base(theEnemy, theStateMachine, theAnimBoolName)
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

        if(Time.time >= startTime + 0.5f)
        {
            enemy.AttackController.Attack();
        }
    }
    // end
}
