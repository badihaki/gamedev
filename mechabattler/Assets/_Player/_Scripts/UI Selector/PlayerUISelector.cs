using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUISelector : MonoBehaviour
{
    public PlayerObject player;
    private CharSelectMaster master;
    private PlayerInputInterface controls;
    private int speed = 750;
    [SerializeField] float rayDist = 10.0f;
    public void InitSelector(PlayerObject setPlayer)
    {
        player = setPlayer;
        master = GameObject.Find("Scene Master").GetComponent<CharSelectMaster>();
        controls = player.GetComponent<PlayerInputInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectSelectableElements();
    }

    private void FixedUpdate()
    {
        MoveSelector();
    }

    private void DetectSelectableElements()
    {
        // lets make our own raycast
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector3.forward, rayDist);

        if (ray.collider != null)
        {
            if (ray.collider.GetComponent<CharacterSelectorContainer>() != null)
                CanSelect(ray.collider.GetComponent<CharacterSelectorContainer>().character);
            else if (ray.collider.name== "StartButton")
            {
                if (controls.JumpButton)
                {
                    master.StartGame();
                }
            }
        }
    }

    void MoveSelector()
    {
        // move position
        transform.Translate((controls.moveInput * speed) * Time.deltaTime);
    }

    private void CanSelect(PlayerCharacter selectedCharacter)
    {
        if (controls.JumpButton)
        {
            player.playerCharacter = selectedCharacter;

            master.ChangeSelectedPlayerImage(player.playerIndex, player.playerCharacter);
        }
    }

    // end of the line
}
