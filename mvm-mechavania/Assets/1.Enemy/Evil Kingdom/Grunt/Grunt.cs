using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    public override void StateMachineInit()
    {
        base.StateMachineInit();

        AttackState = new GruntAttackState(this, StateMachine, "attack");
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    // end
}
