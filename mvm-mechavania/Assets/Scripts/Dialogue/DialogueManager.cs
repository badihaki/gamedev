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
        gameMaster.Player.StateMachine.ChangeState(gameMaster.Player.CinemaState);
    }

    private void ResetUI()
    {
        gameMaster.CinematicUI.GetComponent<Image>().sprite = null;
        gameMaster.CinematicUI.SetActive(false);

        gameMaster.DialogueUI.transform.Find("Speaker").GetComponent<Image>().sprite = null;
        gameMaster.DialogueUI.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = null;
    }

    private void LoadDialogue()
    {
        ResetUI();

        if (CurrentDialogue.cinematic != null)
        {
            gameMaster.CinematicUI.SetActive(true);
            gameMaster.CinematicUI.GetComponent<Image>().sprite = CurrentDialogue.cinematic;
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
        ResetUI();

        gameMaster.DialogueUI.SetActive(false);
        CurrentDialogue = null;
        gameMaster.Player.StateMachine.ChangeState(gameMaster.Player.IdleState);
    }

    // end
}
