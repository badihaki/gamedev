using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMoveController : MonoBehaviour
{
    public Rigidbody2D PhysicsController { get; private set; }
    private MechProperties mecha;

    // Start is called before the first frame update
    void Start()
    {
        PhysicsController = GetComponent<Rigidbody2D>();
        mecha = GetComponent<MechProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyPhysics(float newX, float newY)
    {
        PhysicsController.velocity = new Vector2(newX, newY);
    }
    public void MoveX(int direction)
    {
        Vector2 desiredMove = new Vector2(direction, PhysicsController.velocity.y) * mecha.mech.mechSpeed;
        ApplyPhysics(desiredMove.x, PhysicsController.velocity.y);
    }

}
