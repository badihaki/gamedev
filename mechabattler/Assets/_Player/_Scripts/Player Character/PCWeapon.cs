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
    public WeaponScriptableObj equippedWeapon { get; private set; }
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private GameObject weaponObj;
    public float shotTimer { get; private set; }
    public float shotTimerDemo; // delete this if ManageFireRate is working

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
    public void InitWeapon()
    {
        weaponObj = Instantiate(equippedWeapon.weaponObj, transform.position, transform.rotation, transform);
        shotPoint = weaponObj.transform.Find("Spot");

    }
    public void GetWeapon(WeaponScriptableObj newWeapon)
    {
        // spawn a version of the equipped weapon and toss it out randomly
        // make equipped weapon = null
        if (weaponObj != null)
        {
            print("destroyed equipped weapon " + weaponObj.name);
            Destroy(weaponObj);
        }
        // equip new weapon
        print("getting new weapon: " + newWeapon);
        if (equippedWeapon != null)
        {
            GameObject throwawayWeapon = Instantiate(equippedWeapon.weaponPickup, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            Vector2 randomThrowVector = new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(0f, 5f));
            throwawayWeapon.GetComponent<Rigidbody2D>().AddForce(randomThrowVector, ForceMode2D.Impulse);
        }        
        equippedWeapon = newWeapon;
        weaponObj = Instantiate(equippedWeapon.weaponObj, transform.position, transform.rotation, transform);
        shotPoint = weaponObj.transform.Find("Spot");
    }

    public void FireWeapon()
    {
        // print("shots fired");
        if (shotTimer <= 0)
        {
            shotTimer = equippedWeapon.fireRate;
            GameObject proj = Instantiate(equippedWeapon.projectileObj, shotPoint.position, shotPoint.rotation);
            proj.GetComponent<BulletScript>().Init(equippedWeapon.projSpeed, equippedWeapon.projDamage);
        }
        
    }

}