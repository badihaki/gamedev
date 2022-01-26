using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="weapon",menuName ="Items/Weapons")]
public class WeaponScriptableObj : ScriptableObject
{
    [Header("Game Objects")]
    public GameObject weaponObj;
    public GameObject weaponPickup;
    public GameObject projectileObj;

    [Header("Game Objects")]
    public float fireRate;
    public float projSpeed;
    public int projDamage;
}
