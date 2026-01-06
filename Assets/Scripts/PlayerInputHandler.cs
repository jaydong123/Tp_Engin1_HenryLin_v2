using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent<Vector2> OnMoveInput;
    public UnityEvent OnJumpInput;
    public UnityEvent <Vector2>OnMouseMoveInput;

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

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("OnLook called, context.phase: " + context.phase);
        if (context.performed || context.canceled)
            OnMouseMoveInput?.Invoke(context.ReadValue<Vector2>());
    }
}
