using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Health Health { get; private set; }
    public FXHolder FX { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<Health>();
        FX = GetComponent<FXHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int dmg, int direction, Vector2 pushBack)
    {
        Health.TakeHealth(dmg);
        Instantiate(FX.hitEffect, transform.position, transform.rotation);

        if (Health.CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
