using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    public Room Room;
    public Port _PortEndPoint;
    public Transform playerSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && collision.GetComponent<Player>() != null)
        {
            if(_PortEndPoint!=null)
                GoToRoom(collision.GetComponent<Player>());
        }
    }

    public void GoToRoom(Player player)
    {
        _PortEndPoint.Room.ActivateRoom();
        player.transform.position = _PortEndPoint.playerSpawnPoint.position;
        Room.DeactivateRoom();
    }
}
