using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    Rigidbody2D controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
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
