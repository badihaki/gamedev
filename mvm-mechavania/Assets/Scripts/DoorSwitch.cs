using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    Door door;
    public Sprite offState;
    public Sprite onState;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponentInParent<Door>();
        GetComponent<SpriteRenderer>().sprite = offState;
        if (door.boundary == null)
        {
            GetComponent<SpriteRenderer>().sprite = onState;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && collision.GetComponent<Projectile>() != null)
        {
            door.doorIsWorking = true;
            GetComponent<SpriteRenderer>().sprite = onState;
            Destroy(collision.gameObject);
            Destroy(door.boundary);
            door.boundary = null;
            door.isOpen = true;
        }
    }
}
