using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut00Floor : MonoBehaviour
{
    private GM _GameMaster;
    [SerializeField] private bool trigger;
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        _GameMaster = GameObject.Find("Game Master").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        print(_GameMaster.DialogueManager.CurrentDialogue.name);
        if (_GameMaster.DialogueManager.CurrentDialogue.name == "Tut00" && trigger == false)
        {
            trigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trigger == true && collision.GetComponent<Player>() != null)
        {
            _GameMaster.DialogueManager.StartDialogue(dialogue);
            Destroy(this.gameObject);
        }
    }

    // end
}
