using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gunPosition;

    [SerializeField] private float atkTime;
    [SerializeField] private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = atkTime;
    }

    // Update is called once per frame
    void Update()
    {
        ManageTimer();
    }

    private void ManageTimer()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else if (attackTimer < 0)
            attackTimer = 0;
    }

    public void Attack()
    {
        if (attackTimer <= 0)
        {
            GameObject proj = Instantiate(projectile, gunPosition.position, transform.rotation);
            proj.GetComponent<Projectile>().facingRight = GetComponent<Player>().MoveController.FacingRight;
            attackTimer = atkTime;
        }
    }
}
