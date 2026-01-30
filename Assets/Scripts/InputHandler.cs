using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput;
    public event Action OnJumpInput;
    public event Action<Vector2> OnCameraMoveInput;
    public event Action OnMouseInput;

    private PlayerInput _playerInput;

    private void Awake()
    {
        if (!_playerInput)
            _playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        _playerInput.actions["Move"].performed += OnMovePerformed;
        _playerInput.actions["Move"].canceled += OnMovePerformed;
        _playerInput.actions["Jump"].performed += OnJumpPerformed;
        _playerInput.actions["Move"].performed += OnCameraMovePerformed;
        _playerInput.actions["Move"].canceled += OnCameraMovePerformed;
        _playerInput.actions["SelectEntity"].performed += OnSelectEntity;
    }
    
    private void OnDisable()
    {
        _playerInput.actions["Move"].performed -= OnMovePerformed;
        _playerInput.actions["Move"].canceled -= OnMovePerformed;
        _playerInput.actions["Jump"].performed -= OnJumpPerformed;
        _playerInput.actions["Move"].performed -= OnCameraMovePerformed;
        _playerInput.actions["Move"].canceled -= OnCameraMovePerformed;
    }

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        OnMoveInput?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJumpInput?.Invoke();
    }
    
    public void OnCameraMovePerformed(InputAction.CallbackContext context)
    {
        OnCameraMoveInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSelectEntity(InputAction.CallbackContext context)
    {
        OnMouseInput?.Invoke();
    }
    
}
