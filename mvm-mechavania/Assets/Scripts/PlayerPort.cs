using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPort : MonoBehaviour
{
    private Door door;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponentInParent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            door.GoToRoom(collision.GetComponent<Player>());
        }
    }
}
