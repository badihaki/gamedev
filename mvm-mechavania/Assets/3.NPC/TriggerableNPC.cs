using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableNPC : MonoBehaviour
{
    public Dialogue dialogue;
    private GM _GameMaster;

    // Start is called before the first frame update
    void Start()
    {
        _GameMaster = GameObject.Find("Game Master").GetComponent<GM>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<Player>() != null)
        {
            _GameMaster.DialogueManager.StartDialogue(dialogue);
        }
    }
}
