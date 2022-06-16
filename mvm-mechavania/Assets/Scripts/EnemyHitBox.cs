using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hurtable = collision.GetComponent<IDamageable>();
        if (hurtable == null) return;
        if (collision.tag != enemy.tag)
        {
            int direction;

            if (collision.transform.position.x > transform.position.x)
                direction = -1;
            else direction = 1;

            hurtable.Damage(enemy.attack, direction, enemy.attackForce);
        }
    }
}
