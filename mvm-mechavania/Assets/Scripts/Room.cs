using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject _Grid;
    [SerializeField] private GameObject _Coliders;
    [SerializeField] private GameObject _Props;
    [SerializeField] private GameObject _EnemySpawns;

    private void Awake()
    {
        foreach (Door door in GetComponentsInChildren<Door>())
        {
            door.InitDoor();
        }
        DeactivateRoom();
    }
    public void ActivateRoom()
    {
        _Grid.SetActive(true);
        _Coliders.SetActive(true);
        _Props.SetActive(true);
        _EnemySpawns.SetActive(true);
    }

    public void DeactivateRoom()
    {
        _Grid.SetActive(false);
        _Coliders.SetActive(false);
        _Props.SetActive(false);
        _EnemySpawns.SetActive(false);
    }
    //end
}
