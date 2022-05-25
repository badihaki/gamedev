using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D controller;
    [SerializeField] private Vector2 desiredVelocity;
    [SerializeField] private Player player;
    public bool FacingRight { get; private set; }
    // Start is called before the first frame update
    public void InitController()
    {
        controller = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();

        FacingRight = true;
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
        if (desiredVelocity.x > 0 && !FacingRight)
        {
            Flip();
        }
        else if (desiredVelocity.x < 0 && FacingRight)
        {
            Flip();
        }
        desiredVelocity.x  = direction * player.speed;
    }
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        FacingRight = !FacingRight;
    }
    public void Jump()
    {
        //
        controller.AddForce(new Vector2(desiredVelocity.x, player.jump), ForceMode2D.Impulse);
    }
    public void Eject()
    {
        controller.AddForce(new Vector2(Random.Range(0.5f, 1.75f), player.jump));
    }
}
