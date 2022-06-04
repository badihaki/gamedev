using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Room Room { get; private set; }
    public Door _ConnectedDoor;
    public Transform playerSpawnPoint;
    private bool isOpen;
    private Animator anim;

    public void InitDoor()
    {
        anim = GetComponent<Animator>();
        Room = GetComponentInParent<Room>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
        _ConnectedDoor.Room.ActivateRoom();
        player.transform.position = _ConnectedDoor.playerSpawnPoint.position;
        Room.DeactivateRoom();
    }

}
