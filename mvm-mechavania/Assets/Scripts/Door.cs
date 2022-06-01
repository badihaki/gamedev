using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Door _ConnectedDoor;
    public Transform playerSpawnPoint;
    private bool isOpen;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isOpen", isOpen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("player entered");
            isOpen = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("player entered");
            isOpen = false;
        }
    }

    public void GoToRoom(Player player)
    {
        player.transform.position = _ConnectedDoor.playerSpawnPoint.position;
    }

}
