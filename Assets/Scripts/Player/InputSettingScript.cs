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
    public bool aim;
    public bool sprint;
    public bool dodge;

    [Header("Movement Setting")]
    public bool analogMovement;

    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }
    public void OnLook(InputValue value)
    {
        LookInput(value.Get<Vector2>());
    }
    public void OnJump(InputValue value)
    {
        JumpInput(value.isPressed);
    }
    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }
    public void OnAim(InputValue value)
    {
        AimInput(value.isPressed);
    }
    public void OnDodge(InputValue value)
    {
        DodgeInput(value.isPressed);
    }






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
    public void AimInput(bool newAimState)
    {
        aim = newAimState;
    }
    public void DodgeInput(bool newDodgeState)
    {
        dodge = newDodgeState;
    }

}
