using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUnlock : MonoBehaviour
{
    Player player;
    GM gameMaster;
    public Room room;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameMaster = GameObject.Find("Game Master").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMaster.DialogueManager.CurrentDialogue != null)
        {
            if(gameMaster.DialogueManager.CurrentDialogue.name== "Gun-Unlock02")
            {
                player.AbilityUnlocks._AquiredGun = true;
                Destroy(this.gameObject);
            }
        }
    }

    // end
}
