using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechInteract : MonoBehaviour, IInteractable
{
    MechProperties mech;
    // Awake is called before Start()
    void Awake()
    {
        mech = GetComponentInParent<MechProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact(GameObject player)
    {
        mech.GetNewPilot(player.GetComponentInParent<PCProperties>());
    }

}