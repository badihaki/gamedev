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
    public void GetMoveInput(InputAction.CallbackContext input)
    {
        moveInput = input.ReadValue<Vector2>();
    }
    #endregion
    #region Aiming
    public Vector2 aimInput;
    public void GetAimInput(InputAction.CallbackContext input)
    {
        aimInput = input.ReadValue<Vector2>();
    }
    #endregion
}
