using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PCUI : MonoBehaviour
{
    private PCProperties player;

    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private TMP_Text pcName;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private TMP_Text ammoCount;
    [SerializeField]
    private TMP_Text state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(PCProperties plyer)
    {
        player = plyer;

        // set UI by player index
        if (player.player.playerIndex == 1)
        {
            ui = GameObject.Find("Canvas-Player").transform.Find("P1").gameObject;
        }
        else
        {
            ui = GameObject.Find("Canvas-Player").transform.Find("P2").gameObject;
        }

        // Set PCname to the player's name
        pcName = ui.transform.Find("Name").GetComponent<TMP_Text>();
        pcName.GetComponent<TMP_Text>().text = player.player.playerCharacter.name;
        // Set ref to player health
        healthBar = ui.transform.Find("Health").GetComponent<Slider>();
        healthBar.maxValue = player.player.playerCharacter.health;
        healthBar.value = healthBar.maxValue;
        // Set ref to player ammo
        ammoCount = ui.transform.Find("Clip").GetComponent<TMP_Text>();
        ammoCount.text = player.WeaponController.currentAmmo.ToString();
        // Set state
        state= ui.transform.Find("State").GetComponent<TMP_Text>();
    }

    public void UpdateHealthUI(int health)
    {
        healthBar.value = health;
    }
    public void UpdateAmmoUI(int ammo)
    {
        ammoCount.text = ammo.ToString();
    }
    public void UpdateStateUI(string stateText)
    {
        state.text = stateText;
    }
}
