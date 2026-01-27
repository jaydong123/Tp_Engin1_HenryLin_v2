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
            _cameraPlayerInput = FindObjectOfType<PlayerInput>();
    }

    private void OnEnable()
    {
        _cameraPlayerInput.actions["Move"].performed += OnCameraMovePerformed;
        _cameraPlayerInput.actions["Move"].canceled += OnCameraMovePerformed;
    }

    private void OnDisable()
    {
        _cameraPlayerInput.actions["Move"].performed -= OnCameraMovePerformed;
        _cameraPlayerInput.actions["Move"].canceled -= OnCameraMovePerformed;
    }

    public void OnCameraMovePerformed(InputAction.CallbackContext context)
    {
        OnCameraMoveInput?.Invoke(context.ReadValue<Vector2>());
    }
}
