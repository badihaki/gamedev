using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombsAttackState : EnemyAttackState
{
    public ZombsAttackState(Enemy theEnemy, EnemyStateMachine theStateMachine, string theAnimBoolName) : base(theEnemy, theStateMachine, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(enemy.ChaseState);
        }
    }

    // end
}
