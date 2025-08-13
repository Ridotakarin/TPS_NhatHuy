using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.UI;
#endif
public class InputSettingScript : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool aiming;
    public bool walk;
    public bool sprint;
    public bool reload;

    [Header("Movement Setting")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;
#if ENABLE_INPUT_SYSTEM
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }
    public void OnLook(InputValue value)
    {
        if (cursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }
    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }
    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }
    public void OnWalk(InputValue value)
    {
        WalkInput(value.isPressed);
    }
    public void OnAiming(InputValue value)
    {
        AimingInput(value.isPressed);
    }
    public void OnReload(InputValue value)
    {
        // Gán giá trị isPressed cho biến reload
        // Hành động này sẽ trả về true khi nhấn và false khi nhả
        reload = value.isPressed;
    }
#endif





    public void MoveInput( Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }
    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }
    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }
    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }
    public void WalkInput(bool newWalkState)
    {
        walk = newWalkState;
    }
    public void AimingInput(bool newAimState)
    {
        aiming = newAimState;
    }
    public void ReloadInput(bool newReloadState)
    {
        reload = newReloadState;
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }
    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

}
