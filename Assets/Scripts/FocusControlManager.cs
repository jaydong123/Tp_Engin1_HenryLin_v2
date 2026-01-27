using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FocusControlManager : MonoBehaviour
{

    public enum Focus
    {
        Player,
        Camera,
        Other,
    }
    [SerializeField] private Focus _focus;
    [SerializeField] private PlayerInput _playerInput;
    
    private void Awake()
    {
        if (!_playerInput)
            _playerInput = GetComponent<PlayerInput>();
        SetFocus(Focus.Camera);
    }


    public static event Action<Focus> OnFocusChanged;
    public Focus currentFocus
    {
        get => _focus;
        set
        {
            _focus = value;
            OnFocusChanged?.Invoke(_focus);
        }
    }
    
    [ContextMenu("Set Focus")]
    void SetFocus()
    {
        switch(_focus)
        {
            case Focus.Player:
                _playerInput.SwitchCurrentActionMap("Player");
                break;
            case Focus.Camera:
                _playerInput.SwitchCurrentActionMap("Camera");
                break;
        }
        currentFocus = _focus;
        Debug.Log("Switched focus to: " + _playerInput.currentActionMap.name);
    }
    
    void SetFocus(Focus focus)
    {
        switch(focus)
        {
            case Focus.Player:
                _playerInput.SwitchCurrentActionMap("Player");
                break;
            case Focus.Camera:
                _playerInput.SwitchCurrentActionMap("Camera");
                break;
        }
        currentFocus = focus;
        
        Debug.Log("Switched focus to: " + _playerInput.currentActionMap.name);
    }
}
