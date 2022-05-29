using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool CanActivate { get; private set; }
    public void SetCanActivate()
    {
        CanActivate = !CanActivate;
    }
    private Player player;

    public void Initialize()
    {
        player = GetComponentInParent<Player>();
        CanActivate = true;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (CanActivate)
        {
            if (obj.GetComponent<Interactor>() != null)
            {
                if (player.CurrentInteractableObj == null)
                {
                    // logic for interacting with stuff
                    player.GetNewInteractiveObj(obj.GetComponent<Interactor>());
                    SetCanActivate();
                    obj.GetComponent<Interactor>().ShowGFX();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (player.CurrentInteractableObj != null)
        {
            if (obj.GetComponent<Interactor>() == player.CurrentInteractableObj)
            {
                player.RemoveInteractiveObj();
                SetCanActivate();
                obj.GetComponent<Interactor>().ResetInteract();
            }
        }
    }

    // end of the line
}
