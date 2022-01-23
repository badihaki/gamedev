using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // reference the input system

/// <summary>
/// This class contains functions that dictate input
/// </summary>
public class PlayerInputInterface : MonoBehaviour
{
    #region Movement
    public Vector2 moveInput;
    public int XInput { get; private set; }
    public int YInput { get; private set; }

    public void GetMoveInput(InputAction.CallbackContext input)
    {
        moveInput = input.ReadValue<Vector2>();
        // normalize x and y inputs
        XInput = (int)(moveInput * Vector2.right).normalized.x;
        YInput = (int)(moveInput * Vector2.up).normalized.y;
    }
    #endregion

    #region Aiming
    public Vector2 AimInput { get; private set; }
    public void GetAimInput(InputAction.CallbackContext input)
    {
        AimInput = input.ReadValue<Vector2>();
    }
    #endregion

    #region Fire The Weapon
    public bool FireButton;
    public void GetFireInput(InputAction.CallbackContext input)
    {
        if (input.performed)
        {
            FireButton = true;
        }
        if (input.canceled)
        {
            FireButton = false;
        }
    }
    #endregion
}
