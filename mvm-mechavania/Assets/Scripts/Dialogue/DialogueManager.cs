using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    private GM gameMaster;

    public Dialogue CurrentDialogue { get; private set; }

    private void Start()
    {
        gameMaster = GetComponent<GM>();
    }

    public void StartDialogue(Dialogue newDialogue)
    {
        gameMaster.DialogueUI.SetActive(true);
        CurrentDialogue = newDialogue;
        LoadDialogue();
        // change player state to cinematic
        // gameMaster.Player.StateMachine.ChangeState(gameMaster.Player.CinemaState);
    }

    private void LoadDialogue()
    {
        if (CurrentDialogue.cinematic != null)
        {
            gameMaster.DialogueUI.transform.Find("Cinematic").GetComponent<Image>().sprite = CurrentDialogue.cinematic;
        }
        if (CurrentDialogue.speakerImage != null)
        {
            gameMaster.DialogueUI.transform.Find("Speaker").GetComponent<Image>().sprite = CurrentDialogue.speakerImage;
        }
        if (CurrentDialogue.dialogue != null)
        {
            gameMaster.DialogueUI.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = CurrentDialogue.dialogue;
        }
    }

    public void StartNextDialogue()
    {
        if (CurrentDialogue.nextDialogue == null)
            EndDialogue();
        else
        {
            CurrentDialogue = CurrentDialogue.nextDialogue;
            LoadDialogue();
        }
    }

    private void EndDialogue()
    {
        CurrentDialogue = null;
        gameMaster.Player.StateMachine.ChangeState(gameMaster.Player.IdleState);
    }

    // end
}
