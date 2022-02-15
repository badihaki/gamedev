using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the main player class
/// Controls what type of gameplay mode we are in
/// Interfaces with control input
/// </summary>
public class PlayerObject : MonoBehaviour
{
    public PlayerCharacter playerCharacter;
    public GameObject userInterfaceImage;

    public int playerHealth;

    public int playerIndex = 0;

    public bool testMode;

    public PlayerInputInterface Controls { get; private set; }

    /*
     * First order of business is to detect input
     * ^^ Input will be read by the player character object
     * 
     * This script will also help determine what mode we're in (gameplay or menus)
     */

    // Awake is called before Start
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Controls = GetComponent<PlayerInputInterface>();

        // below we are going to initialize gameplay
        if(testMode)
            InitGameplay(GameObject.Find("Start").transform);
        // in the real game, the scene will call InitGameplay() when it's ready to initalize the player
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectCharacter(PlayerCharacter mychar)
    {
        playerCharacter = mychar;
    }

    public void InitGameplay(Transform startingPoint)
    {
        GameObject pc = Instantiate(playerCharacter.playerCharObj, startingPoint.position, Quaternion.identity);
        pc.GetComponent<PCProperties>().player = this;

        // lets initialize their gameplay, then state machine
        pc.GetComponent<PCProperties>().InitGameplay(this);

        // set player health
        playerHealth = playerCharacter.health;
    }
}
