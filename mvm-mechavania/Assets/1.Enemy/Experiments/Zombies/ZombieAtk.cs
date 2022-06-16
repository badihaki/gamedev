using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAtk : EnemyAttackController
{
    public override void Attack()
    {
        if (enemy.MoveController.FacingRight)
        {
            enemy.MoveController.Move(1, 1);
        }
        else
        {
            enemy.MoveController.Move(-1, 1);
        }

        base.Attack();
    }

    // end
}
