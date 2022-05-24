using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntAttack : EnemyAttackController
{
    public GameObject projectile;

    public Transform shootPoint;
    // Start is called before the first frame update
    public override void Start()
    {
        enemy = GetComponent<Grunt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        base.Attack();

        GameObject proj = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        if (enemy.MoveController.FacingRight)
        {
            proj.GetComponent<Projectile>().facingRight = true;
        }
        else
            proj.GetComponent<Projectile>().facingRight = false;

        ResetAttack();
    }
}
