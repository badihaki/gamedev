using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    // Start is called before the first frame update
    public override void StateMachineInit()
    {
        base.StateMachineInit();

        AttackState = new ZombsAttackState(this, StateMachine, "attack");
    }

    public override void EndAnimation()
    {
        base.EndAnimation();

        MoveController.ZeroVelocityX();
    }
    // end
}
