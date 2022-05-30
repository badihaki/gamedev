using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        SyncHealthUI();
    }

    public void SyncHealthUI()
    {
        healthUI.text = player.Health.CurrentHealth.ToString();
    }
}
