using System;
using UnityEngine;

public class FocusControlManager : MonoBehaviour
{
    [SerializeField] GameObject gameObjectInputHandler;
    [SerializeField] private InputHandler _inputHandler;
    
    public enum Focus
    {
        Player,
        Camera,
        Other,
    }
    [SerializeField] private Focus _focus;

    private void Awake()
    {
        if (!_inputHandler)
            _inputHandler = gameObjectInputHandler.GetComponent<InputHandler>();

        currentFocus = _focus;
    }
    
    private void OnEnable()
    {
        _inputHandler.OnMouseInput += SetFocusByMouseInput;
    }    
    
    private void OnDisable()
    {
        _inputHandler.OnMouseInput -= SetFocusByMouseInput;
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
        currentFocus = _focus;
    }

    private void SetFocusByMouseInput()
    {
        Debug.Log("SetFocusByMouseInput"); // it works
    }
}
