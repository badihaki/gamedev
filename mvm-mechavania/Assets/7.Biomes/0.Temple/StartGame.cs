using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Room startingRoom;
    public Dialogue startingDialogue;
    GM gameMaster;
    Player player;
    public EnemyBlockade[] enemyBlockades;
    public bool testMode;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("Game Master").GetComponent<GM>();

        gameMaster.Initialize();

        player = GameObject.Find("Player").GetComponent<Player>();
        player.transform.position = transform.position;
        if (!testMode)
        {
            startingRoom.ActivateRoom();
            gameMaster.DialogueManager.StartDialogue(startingDialogue);
        }
        else
        {
            InitiateUnlocks();
        }
    }

    private void InitiateUnlocks()
    {
        player.AbilityUnlocks._AquiredGun = true;
        player.AbilityUnlocks._AquiredGrenades = true;
        player.AbilityUnlocks._AquiredBoostJump = true;
        player.AbilityUnlocks._AquiredAI = true;
    }

    private void Update()
    {
        if (gameMaster.DialogueManager.CurrentDialogue == null)
        {
            foreach (EnemyBlockade blockade in enemyBlockades)
            {
                blockade.activelyActing = true;
            }
            Destroy(gameObject);
        }
    }
}
