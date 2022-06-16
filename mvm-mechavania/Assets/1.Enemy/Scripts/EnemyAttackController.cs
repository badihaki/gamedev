using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField]protected Enemy enemy;

    [SerializeField] private float maxAttackTime;
    [SerializeField] private float minAttackTime;
    [SerializeField] private float attackTimer;
    public bool IsAttacking { get; protected set; }
    public bool amIattacking;

    // Start is called before the first frame update
    public virtual void Start()
    {
        enemy = GetComponent<Enemy>();
        
        IsAttacking = false;
        attackTimer = Random.Range(minAttackTime, maxAttackTime);
    }

    // Update is called once per frame
    void Update()
    {
        amIattacking = IsAttacking;
    }

    public void HandleAttackTimer()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            IsAttacking = false;

        }
        else if (attackTimer < 0)
        {
            IsAttacking = true;
        }
    }
    public void ResetAttack()
    {
        IsAttacking = false;
        attackTimer = Random.Range(minAttackTime, maxAttackTime);
    }

    public virtual void Attack()
    {
        print("resetting attack");
        ResetAttack();
    }

    // end
}
