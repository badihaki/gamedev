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
    public Vector2 aim;
    public void GetAimInput(InputAction.CallbackContext input)
    {
        AimInput = input.ReadValue<Vector2>();

        aim = input.ReadValue<Vector2>().normalized;
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

    #region Reloading
    public bool ReloadButton { get; private set; }

    public void GetReloadInput(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            ReloadButton = true;
        }
        else if (input.canceled)
        {
            ReloadButton = false;
        }
    }
    public void UseReloadButton()
    {
        ReloadButton = false;
    }
    #endregion

    #region Weapon Alt Fire
    public bool AltFireButton { get; private set; }
    public void GetAltFireInput(InputAction.CallbackContext input)
    {
        if (input.performed)
        {
            AltFireButton = true;
        }
        else if (input.canceled)
        {
            AltFireButton = false;
        }
    }
    #endregion

    #region Jumping
    public bool JumpButton;
    public void GetJumpInput(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            JumpButton = true;
        }
        else if (input.canceled)
        {
            JumpButton = false;
        }
    }
    public void UseJump() => JumpButton = false;
    #endregion

    #region Interaction Button
    public bool InteractButton { get; private set; }
    public void GetInteractInput(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            InteractButton = true;
        }
        else if (input.canceled)
        {
            InteractButton = false;
        }
    }
    public void UseInteractButton() => InteractButton = false;
    #endregion

    #region Movement Ability
    public bool MoveAbilityButton { get; private set; }
    public void GetMoveAbilityInput(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            MoveAbilityButton = true;
        }
        else if (input.canceled)
        {
            MoveAbilityButton = false;
        }
    }
    public void UseMoveAbility() => MoveAbilityButton = false;
    #endregion

    #region Ability 1
    public bool Abiltiy1Input { get; private set; }
    public void GetAbility1Input(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Abiltiy1Input = true;
        }
        else if (input.canceled)
        {
            Abiltiy1Input = false;
        }
    }
    public void UseAbility1()
    {
        Abiltiy1Input = false;
    }
    #endregion

    #region Ability 2
    public bool Abiltiy2Input { get; private set; }
    public void GetAbility2Input(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Abiltiy2Input = true;
        }
        else if (input.canceled)
        {
            Abiltiy2Input = false;
        }
    }
    public void UseAbility2()
    {
        Abiltiy2Input = false;
    }
    #endregion
}
