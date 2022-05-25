using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] private Interactor interactor;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GM gameMaster;
    bool isInteracting;

    // Start is called before the first frame update
    void Start()
    {
        interactor = GetComponentInChildren<Interactor>();
        gameMaster = GameObject.Find("Game Master").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactor.Interact && !isInteracting)
        {
            gameMaster.DialogueManager.StartDialogue(dialogue);
            interactor.ResetInteract();
        }
    }
}
