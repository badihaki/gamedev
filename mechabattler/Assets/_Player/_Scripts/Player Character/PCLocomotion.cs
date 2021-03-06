using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCLocomotion : MonoBehaviour
{
    PlayerObject player;
    public Rigidbody2D PhysicsController { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PCProperties>().player;
        PhysicsController = GetComponent<Rigidbody2D>();
        ResetJumpCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyPhysics(float newX, float newY)
    {
        PhysicsController.velocity = new Vector2(newX, newY);
    }

    /// <summary>
    /// Move the player towards a specific direction
    /// </summary>
    /// <param name="direction"></param>
    public void MovePlayerX(int direction)
    {
        Vector2 desiredMove = new Vector2(direction, PhysicsController.velocity.y) * player.playerCharacter.speed;
        ApplyPhysics(desiredMove.x, PhysicsController.velocity.y);
    }

    #region Jumping
    public int jumpCount;
    public void Jump()
    {
        // physicsController.AddForce(new Vector2(physicsController.velocity.x, player.playerCharacter.jumpForce), ForceMode2D.Impulse);
        // physicsController.velocity = new Vector2(physicsController.velocity.x, 1) * player.playerCharacter.jumpForce;
        // physicsController.velocity = Vector2.up * player.playerCharacter.jumpForce;
        // physicsController.AddForce(Vector2.up + jumpDir);
        //physicsController.velocity = jumpDir;
        if (jumpCount > 0)
        {
            // use a jump
            jumpCount--;
            Vector2 jumpDir = new Vector2(PhysicsController.velocity.x, player.playerCharacter.jumpForce); // this code makes me jump
            ApplyPhysics(PhysicsController.velocity.x, jumpDir.y);
        }
    }
    public void SetCoyoteJumpCount()
    {
        // this function will give us a chance to jump if we fall off a ground layer into nothingness........
        jumpCount = player.playerCharacter.maxJumps - 1;
        if (jumpCount <= 0)
        {
            jumpCount = 1;
        }
    }
    public void ZeroJumpCount()
    {
        jumpCount = 0;
    }
    public void ResetJumpCount()
    {
        jumpCount = player.playerCharacter.maxJumps;
    }
    #endregion
}
