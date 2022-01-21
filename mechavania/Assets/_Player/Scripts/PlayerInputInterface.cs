using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputInterface : MonoBehaviour
{
    [SerializeField]
    private Vector2 MovementInput;
    #region Movement
    public int Xinput { get; private set; }
    public int Yinput { get; private set; }
    public void GetMoveInput(InputAction.CallbackContext inputVec)
    {
        MovementInput = inputVec.ReadValue<Vector2>();
        // normalize x and y inputs and store them in their own var
        Xinput = (int)(MovementInput * Vector2.right).normalized.x;
        Yinput = (int)(MovementInput * Vector2.up).normalized.y;
    }
    #endregion

    #region Jump
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
    #endregion
}
