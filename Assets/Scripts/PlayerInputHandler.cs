using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent<Vector2> OnMoveInput;
    public UnityEvent OnJumpInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            OnMoveInput?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            OnJumpInput?.Invoke();
    }
}
