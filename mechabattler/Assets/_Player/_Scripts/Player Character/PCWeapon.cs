using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(PCInteract))]
public class PCWeapon : MonoBehaviour
{
    PCProperties pc;
    PlayerObject player;
    Vector2 aim;
    [SerializeField]
    float aimOffset;
    public WeaponScriptableObj equippedWeapon { get; private set; }
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private GameObject weaponObj;
    [SerializeField]
    private float shotTimer;
    public float shotTimerDemo; // delete this if ManageFireRate is working
    [Header("Ammo And Reloading")]
    public int currentAmmo;
    [SerializeField]
    private float reloadTimer;
    [SerializeField]
    private bool isReloading;

    // Start is called before the first frame update
    void Start()
    {
        // player = GetComponentInParent<PCProperties>().player;
        pc = GetComponentInParent<PCProperties>();
        player = pc.player;
    }

    // The function to initialize the weapon on pickup
    public void InitWeapon()
    {
        weaponObj = Instantiate(equippedWeapon.weaponObj, transform.position, transform.rotation, transform);
        shotPoint = weaponObj.transform.Find("Spot");
        currentAmmo = equippedWeapon.clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        // manage the fire rate
        ManageFireRate();
        // manage reloading
        if (isReloading == true)
        {
            ReloadWeapon();
        }
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

    private void ReloadWeapon()
    {
        reloadTimer -= Time.deltaTime;

        if (reloadTimer <= 0.0f)
        {
            isReloading = false;
            reloadTimer = equippedWeapon.reloadSpeed;
            currentAmmo = equippedWeapon.clipSize;
            pc.UI.UpdateAmmoUI(currentAmmo); //update ammo in the UI
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

    public void GetWeapon(WeaponScriptableObj newWeapon)
    {
        // equip new weapon
        print("getting new weapon: " + newWeapon);
        if (equippedWeapon != null)
        {
            // if there is already an equipped weapon, do this below
            if (weaponObj != null)
            {
                Destroy(weaponObj);
            }
            // spawn a version of the equipped weapon and toss it out randomly
            GameObject throwawayWeapon = Instantiate(equippedWeapon.weaponPickup, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            Vector2 randomThrowVector = new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(0f, 5f));
            throwawayWeapon.GetComponent<Rigidbody2D>().AddForce(randomThrowVector, ForceMode2D.Impulse);
        }        
        // make equipped weapon = new weapon
        equippedWeapon = newWeapon;
        weaponObj = Instantiate(equippedWeapon.weaponObj, transform.position, transform.rotation, transform);
        shotPoint = weaponObj.transform.Find("Spot");
        currentAmmo = equippedWeapon.clipSize;
        reloadTimer = equippedWeapon.reloadSpeed;
        pc.UI.UpdateAmmoUI(currentAmmo); //update ammo in the UI
    }

    public void FireWeapon()
    {
        if (currentAmmo > 0 && equippedWeapon != null)
        {
            if (shotTimer <= 0)
            {
                shotTimer = equippedWeapon.fireRate;
                currentAmmo -= 1;
                pc.UI.UpdateAmmoUI(currentAmmo); //update ammo in the UI
                GameObject proj = Instantiate(equippedWeapon.projectileObj, shotPoint.position, shotPoint.rotation);
                proj.GetComponent<BulletScript>().Init(equippedWeapon.projSpeed, equippedWeapon.projDamage);
            }
        }
        else if (currentAmmo <= 0)
        {
            isReloading = true;
        }
        // else nothing happens
    }

}