using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(PCWeapon))]
public class PCInteract : MonoBehaviour
{
    /*
     * the purpose of this script is to have our pc interact with
     * the environment. Whether that be pressing buttons or picking
     * up items or whatnot
     */
    [SerializeField]
    Transform interactableObject;
    [SerializeField]
    IInteractable interactTarget;
    [SerializeField]
    GameObject uiDetectIcon;
    GameObject uiTrack;

    public void InteractWith()
    {
        if (interactableObject != null)
        {
            print("interacting with " + interactableObject);
            var interactable = interactableObject.GetComponent<IInteractable>();
            if (interactable == null) return;
            interactable.Interact(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.GetComponent<IInteractable>() != null)
        {
            interactableObject = trigger.transform;
            uiTrack = Instantiate(uiDetectIcon, new Vector2(interactableObject.transform.position.x, interactableObject.transform.position.y + 1.25f), Quaternion.identity, interactableObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.transform == interactableObject)
        {
            Destroy(uiTrack);
            uiTrack = null;
            interactableObject = null;
        }
    }
}
