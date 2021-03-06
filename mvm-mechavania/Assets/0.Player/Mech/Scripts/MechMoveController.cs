using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D controller;
    [SerializeField] private Vector2 desiredVelocity;
    [SerializeField] private Mech mech;
    [SerializeField] private bool facingRight;
    // Start is called before the first frame update
    public void InitController()
    {
        controller = GetComponent<Rigidbody2D>();
        mech = GetComponent<Mech>();

        facingRight = true;
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
        if (desiredVelocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (desiredVelocity.x < 0 && facingRight)
        {
            Flip();
        }
        desiredVelocity.x = direction * mech.speed;
    }
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    public void Jump()
    {
        //
        controller.AddForce(new Vector2(desiredVelocity.x, mech.jump), ForceMode2D.Impulse);
    }
}
