using System;
using UnityEngine;

public class FocusControlManager : MonoBehaviour
{

    public enum Focus
    {
        Player,
        Camera,
        Other,
    }
    
    [SerializeField] private Focus _focus;
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
}
