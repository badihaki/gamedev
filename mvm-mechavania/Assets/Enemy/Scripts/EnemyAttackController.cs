using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private Enemy enemy;

    [SerializeField] private float maxAttackTime;
    [SerializeField] private float minAttackTime;
    [SerializeField] private float attackTimer;
    public bool IsAttacking { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        
        IsAttacking = false;
        attackTimer = Random.Range(minAttackTime, maxAttackTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleAttackTimer()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
        {
            attackTimer = 0;
            IsAttacking = true;
        }
    }
    public void ResetAttack()
    {
        IsAttacking = false;
        attackTimer = Random.Range(minAttackTime, maxAttackTime);
    }


    // end
}
