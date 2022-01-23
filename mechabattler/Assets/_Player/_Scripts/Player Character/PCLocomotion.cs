using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCLocomotion : MonoBehaviour
{
    PlayerObject player;
    private Rigidbody2D physicsController;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PCProperties>().player;
        physicsController = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Move the player towards a specific direction
    /// </summary>
    /// <param name="direction"></param>
    public void MovePlayer(int direction)
    {
        physicsController.velocity = new Vector2(direction, physicsController.velocity.y) * player.playerCharacter.speed;
    }
}
