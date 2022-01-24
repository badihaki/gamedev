using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCWeapon : MonoBehaviour
{
    PlayerObject player;
    Vector2 aim;
    [SerializeField]
    float aimOffset;
    [SerializeField]
    Transform bulletOrigin;
    [SerializeField]
    public float shotTimer { get; private set; }
    public float shotTimerDemo; // delete this if ManageFireRate is working
    // we gonna have to add the stuff below into the 'Weapon' scriptable obj
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PCProperties>().player;
    }

    // Update is called once per frame
    void Update()
    {
        ManageFireRate();
    }

    private void ManageFireRate()
    {
        shotTimerDemo = shotTimer; //delete laters

        if (shotTimer > 0)
        {
            shotTimer -= Time.deltaTime;
        }
        if (shotTimer < 0)
        {
            shotTimer = 0;
        }
    }

    public void FollowAim()
    {
        // first get the aim from the player's root
        aim = player.Controls.AimInput;

        // next calc diff between weapon's transform and mouse transform
        Vector2 differenceBetweenWeaponAndMouse = Camera.main.ScreenToWorldPoint(aim) - transform.position;
        // obtain the desired rotation of Z
        float rotateOnZ = Mathf.Atan2(differenceBetweenWeaponAndMouse.y, differenceBetweenWeaponAndMouse.x) * Mathf.Rad2Deg;
        // Apply desired rotation of Z
        transform.rotation = Quaternion.Euler(0f, 0f, rotateOnZ + aimOffset);
    }

    public void FireWeapon()
    {
        // print("shots fired");
        if (shotTimer <= 0)
        {
            shotTimer = fireRate;
            Instantiate(projectile, bulletOrigin.position, transform.rotation);
        }
        
    }
}
