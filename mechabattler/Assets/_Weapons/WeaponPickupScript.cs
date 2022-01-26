using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScript : MonoBehaviour, IInteractable
{
    [SerializeField]
    private WeaponScriptableObj weaponPickup;

    public void Interact(GameObject player)
    {
        player.GetComponent<PCWeapon>().GetWeapon(weaponPickup);
        Destroy(gameObject);
    }
}
