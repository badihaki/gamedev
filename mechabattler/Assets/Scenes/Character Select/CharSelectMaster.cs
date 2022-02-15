using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelectMaster : MonoBehaviour
{
    public GameMaster gameMaster { get; private set; }
    [SerializeField]
    int nextPlayerIndex = 1;
    [Header("UI Stuff")]
    [SerializeField]
    GameObject characterContainerElement;
    [SerializeField]
    GameObject instructionsMenu;
    [SerializeField]
    GameObject startMenu;
    [SerializeField]
    Image player1UIImage;
    [SerializeField]
    Image player2UIImage;
    bool player1Ready;
    bool player2Ready;

    private void Start()
    {
        gameMaster = GameObject.Find("Game Master").GetComponent<GameMaster>();
        characterContainerElement = GameObject.Find("Character Selection");
        instructionsMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    public void OnPlayerJoined(PlayerInput player)
    {
        // get new player, set their index
        print("player joined");
        PlayerObject newplyr = player.GetComponent<PlayerObject>();
        newplyr.playerIndex = nextPlayerIndex;
        newplyr.name = "player" + nextPlayerIndex.ToString();
        //give to the GM for GM management
        gameMaster.GetNewPlayer(newplyr); // this is the var used to interface with the PlayerObj
        
        // instantiate the selector from newplyr so we have a UI element to interface with
        GameObject selector = Instantiate(newplyr.userInterfaceImage, characterContainerElement.transform.position, Quaternion.identity, characterContainerElement.transform);
        // get the selector script
        PlayerUISelector selectorScr = selector.GetComponent<PlayerUISelector>();
        // and set the color
        if (nextPlayerIndex == 1)
        {
            selector.GetComponent<Image>().color = Color.red;
        }
        else
        {
            selector.GetComponent<Image>().color = Color.blue;
        }
        // initialize the selector
        selectorScr.InitSelector(newplyr);

        // up the new player index
        nextPlayerIndex++;
    }

    public void ChangeSelectedPlayerImage(int playerIndex, PlayerCharacter character)
    {
        if (playerIndex == 1)
        {
            player1UIImage.sprite = character.characterPortrait;
            player1Ready = true;
        }
        else
        {
            player2UIImage.sprite = character.characterPortrait;
            player2Ready = true;
        }

        // check if players are ready
        if (player1Ready == true && player2Ready == true)
        {
            instructionsMenu.SetActive(false);
            startMenu.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("versustest");
    }

    // end of the line
}
