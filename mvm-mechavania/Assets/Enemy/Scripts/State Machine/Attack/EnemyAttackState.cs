using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy theEnemy, EnemyStateMachine theStateMachine, string theAnimBoolName) : base(theEnemy, theStateMachine, theAnimBoolName)
    {
    }

    public override void Exit()
    {
        base.Enter();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (!enemy.AttackController.IsAttacking)
        {
            stateMachine.ChangeState(enemy.ChaseState);
        }
    }

    // end
}
