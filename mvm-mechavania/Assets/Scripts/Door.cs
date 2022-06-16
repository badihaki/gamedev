using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Room Room { get; private set; }
    public Door _ConnectedDoor;
    public bool doorIsWorking;
    public GameObject boundary;
    public Transform playerSpawnPoint;
    public bool isOpen;
    private Animator anim;

    public void InitDoor()
    {
        anim = GetComponent<Animator>();
        Room = GetComponentInParent<Room>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (boundary == null)
        {
            doorIsWorking = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsWorking)
        {
            anim.SetBool("isOpen", isOpen);
            if(boundary.activeSelf == true)
            {
                boundary.SetActive(false);
            }
        }
        else
        {
            if (boundary.activeSelf == false)
            {
                boundary.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorIsWorking)
        {
            if(collision.gameObject.GetComponent<Player>() != null)
            {
                Debug.Log("player entered");
                isOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (doorIsWorking)
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                Debug.Log("player entered");
                isOpen = false;
            }
        }
    }

    public void GoToRoom(Player player)
    {
        _ConnectedDoor.Room.ActivateRoom();
        player.transform.position = _ConnectedDoor.playerSpawnPoint.position;
        Room.DeactivateRoom();
    }

}
