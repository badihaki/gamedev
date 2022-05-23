using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 force;
    [SerializeField] private float destroyTime;
    private Rigidbody2D controller;
    public bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
        controller = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(facingRight)
            controller.velocity = Vector2.right * speed;
        else
            controller.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        if (collision.tag != gameObject.tag)
        {
        var hurtable = collision.GetComponent<IDamageable>();
        if (hurtable == null)
                return;

        int direction;

            if (collision.transform.position.x > transform.position.x)
                direction = -1;
            else direction = 1;

            hurtable.Damage(damage, direction, force);
            Destroy(this.gameObject);
        }
    }
}
