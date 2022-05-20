using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public int Xinput { get; private set; }
    public int Yinput { get; private set; }
    public Vector2 moveInput;
    public void GetMoveInput(InputAction.CallbackContext input)
    {
        moveInput = input.ReadValue<Vector2>();
        Xinput = (int)(moveInput * Vector2.right).normalized.x;
        Yinput = (int)(moveInput * Vector2.up).normalized.y;
    }
    public bool JumpButton { get; private set; }
    public void GetJumpInput(InputAction.CallbackContext button)
    {
        if (button.started)
            JumpButton = true;
        else if (button.canceled)
            JumpButton = false;
    }
    public void UseJump()
    {
        JumpButton = false;
    }
    public bool AttackButton { get; private set; }
    public void GetAttackInput(InputAction.CallbackContext button)
    {
        if (button.started)
            AttackButton = true;
        else if (button.canceled)
            AttackButton = false;
    }
    public bool InteractButton { get; private set; }
    public void GetInteractInput(InputAction.CallbackContext button)
    {
        if (button.started)
            InteractButton = true;
        else if (button.canceled)
            InteractButton = false;
    }
    // end
}
