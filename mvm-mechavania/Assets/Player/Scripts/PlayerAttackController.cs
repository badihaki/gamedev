using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    Player player;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gunPosition;

    [SerializeField] private float atkTime;
    [SerializeField] private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        attackTimer = atkTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.AbilityUnlocks._AquiredGun)
            ManageTimer();
    }

    private void ManageAnim()
    {
        player.Anim.SetBool("attack", player.Controls.AttackButton);
    }

    private void ManageTimer()
    {
        ManageAnim();

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else if (attackTimer < 0)
            attackTimer = 0;
    }

    public void Attack()
    {
        if (player.AbilityUnlocks._AquiredGun)
        {
            if (attackTimer <= 0)
            {
                GameObject proj = Instantiate(projectile, gunPosition.position, transform.rotation);
                proj.GetComponent<Projectile>().facingRight = GetComponent<Player>().MoveController.FacingRight;
                attackTimer = atkTime;
            }
        }
    }

    // end
}
