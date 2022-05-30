using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    private Enemy enemy;
    private Rigidbody2D controller;

    [SerializeField] private Vector2 desiredVelocity;

    public bool FacingRight { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        controller = GetComponent<Rigidbody2D>();
        FacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        controller.velocity = new Vector2(desiredVelocity.x, controller.velocity.y);
    }

    public void Move(int direction, float speedModifier)
    {

        desiredVelocity.x = direction * (enemy.speed * speedModifier);
    }
    public void ZeroVelocityX()
    {
        desiredVelocity.x = 0;
        controller.velocity = desiredVelocity;
    }
    public void Chase()
    {
        enemy.Target.TrackTarget();
        if (enemy.Target.Target.position.x > transform.position.x)
        {
            //print("player on right");
            //if (!FacingRight)
            //Flip();
            Move(1, 1);
        }
        else
        {
            //print("player on left");
            //if (FacingRight)
            //Flip();
            Move(-1, 1);
        }
    }
    public void Retreat()
    {

    }
    public void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        FacingRight = !FacingRight;
    }

    public void Bump(Vector2 pushBack)
    {
        Debug.Log(pushBack);
        controller.AddForce(pushBack, ForceMode2D.Impulse);
    }
}
