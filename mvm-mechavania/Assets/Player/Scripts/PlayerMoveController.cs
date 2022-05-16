using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody2D controller;
    // Start is called before the first frame update
    void InitController()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        
    }

    public void Move()
    {
        //
    }
    public void Jump()
    {
        //
    }
}
