using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float speed;
    int damage;
    public float lifetime;
    Rigidbody2D controller;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Init(float setSpeed, int setDmg)
    {
        controller = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
        speed = setSpeed;
        damage = setDmg;
    }

    // Update is called once per frame
    void Update()
    {
        controller.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // destroy this obj if it collides with something hittable
    }
}
