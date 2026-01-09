using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput;
    public event Action OnJumpInput;

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
    }
    
    private void OnDisable()
    {
        _playerInput.actions["Move"].performed -= OnMovePerformed;
        _playerInput.actions["Move"].canceled -= OnMovePerformed;
        _playerInput.actions["Jump"].performed -= OnJumpPerformed;
    }

    public void OnMovePerformed(InputAction.CallbackContext context)
    {
        OnMoveInput?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJumpInput?.Invoke();
    }
}
