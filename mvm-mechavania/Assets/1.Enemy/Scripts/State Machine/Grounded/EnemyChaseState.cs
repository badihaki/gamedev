using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyGroundedState
{
    public EnemyChaseState(Enemy theEnemy, EnemyStateMachine theStateMachine, string theAnimBoolName) : base(theEnemy, theStateMachine, theAnimBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        // Distance
        // Vector2 distance = enemy.transform.position - target.GetComponentInParent<Player>().transform.position;
        float distance;
        if (enemy.Target.Target != null)
        {
            distance = Vector3.Distance(enemy.transform.position, target.transform.position);
        }
        else
            distance = 0;
        //
        // Attacks
        enemy.AttackController.HandleAttackTimer();
        //

        if (!isExitingState)
        {
            if (distance > enemy.desiredDistanceToPlayer)
                enemy.MoveController.Chase();
            else
                enemy.MoveController.ZeroVelocityX();
        }
    }

    public override void TransitionConditions()
    {
        base.TransitionConditions();

        if (enemy.Target.Target == null)
        {
            stateMachine.ChangeState(enemy.SearchState);
        }

        if (enemy.AttackController.IsAttacking)
        {
            stateMachine.ChangeState(enemy.AttackState);
        }
    }
}
