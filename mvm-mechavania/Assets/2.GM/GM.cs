using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM : MonoBehaviour
{
    public Player Player { get; private set; }
    public DialogueManager DialogueManager { get; private set; }
    public GameObject UI { get; private set; }
    public GameObject DialogueUI { get; private set; }
    public GameObject CinematicUI { get; private set; }
    private GameObject PlayerUI;
    public TextMeshProUGUI PlayerHealth { get; private set; }

    // awake is called before Start
    private void Awake()
    {
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Initialize()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();

        DialogueManager = GetComponent<DialogueManager>();

        UI = transform.Find("UI").gameObject;
        DialogueUI = UI.transform.Find("Dialogue").gameObject;
        DialogueUI.SetActive(false);
        CinematicUI = UI.transform.Find("Cinematic").gameObject;
        CinematicUI.SetActive(false);
        PlayerUI = UI.transform.Find("Player").gameObject;
        PlayerHealth = PlayerUI.transform.Find("Health").GetComponent<TextMeshProUGUI>();

        Player.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
