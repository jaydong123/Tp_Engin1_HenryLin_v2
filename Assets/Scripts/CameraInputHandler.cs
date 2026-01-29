using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputHandler : MonoBehaviour
{
    public event Action<Vector2> OnCameraMoveInput;

    private PlayerInput _cameraPlayerInput;

    private void Awake()
    {
        if (!_cameraPlayerInput)
            _cameraPlayerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _cameraPlayerInput.actions["Move"].performed += OnCameraMovePerformed;
        _cameraPlayerInput.actions["Move"].canceled += OnCameraMovePerformed;
        FocusControlManager.OnFocusChanged += OnFocusChanged;
    }

    private void OnDisable()
    {
        _cameraPlayerInput.actions["Move"].performed -= OnCameraMovePerformed;
        _cameraPlayerInput.actions["Move"].canceled -= OnCameraMovePerformed;
        FocusControlManager.OnFocusChanged -= OnFocusChanged;
    }

    public void OnCameraMovePerformed(InputAction.CallbackContext context)
    {
        OnCameraMoveInput?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnFocusChanged(FocusControlManager.Focus focus)
    {
        // switch(focus)
        // {
        //     case FocusControlManager.Focus.Player:
        //         _cameraPlayerInput.SwitchCurrentActionMap("Player");
        //         break;
        //     case FocusControlManager.Focus.Camera:
        //         _cameraPlayerInput.SwitchCurrentActionMap("Camera");
        //         break;
        // }
    }
}
