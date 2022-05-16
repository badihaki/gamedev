using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D controller;
    [SerializeField] private Vector2 desiredVelocity;
    [SerializeField] private Player player;
    // Start is called before the first frame update
    public void InitController()
    {
        controller = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    public void Update()
    {
        //
    }

    public void FixedUpdate()
    {
        controller.velocity = new Vector2(desiredVelocity.x, controller.velocity.y);
    }

    public void Move(int direction)
    {
        desiredVelocity.x  = direction * player.speed;
        print(direction);
        print(desiredVelocity);
    }
    public void Jump()
    {
        //
    }
}
