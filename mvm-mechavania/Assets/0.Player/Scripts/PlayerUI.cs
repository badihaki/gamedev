using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private Player player;
    private TextMeshProUGUI healthUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Initialize()
    {
        player = GetComponent<Player>();
        healthUI = GameObject.Find("Game Master").GetComponent<GM>().PlayerHealth;
        healthUI.text = player.Health.CurrentHealth.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
