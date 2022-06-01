using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private bool isActive;

    public void ActivateRoom()
    {
        isActive = true;
    }

    public void DeactivateRoom()
    {
        isActive = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
