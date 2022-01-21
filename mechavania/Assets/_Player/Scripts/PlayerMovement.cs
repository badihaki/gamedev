using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _PhysicsController;

    private Vector2 desiredVelocity;

    private PlayerCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        _PhysicsController = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovePlayer(int xVelocity)
    {
        desiredVelocity.x = xVelocity;
        _PhysicsController.velocity = desiredVelocity;
    }
}
