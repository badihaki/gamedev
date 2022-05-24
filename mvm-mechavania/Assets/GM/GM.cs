using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public Player Player { get; private set; }
    public DialogueManager DialogueManager { get; private set; }
    public GameObject UI { get; private set; }
    public GameObject DialogueUI { get; private set; }
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();

        DialogueManager = GetComponent<DialogueManager>();

        UI = GameObject.Find("UI");
        DialogueUI = UI.transform.Find("Dialogue").gameObject;
        DialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
