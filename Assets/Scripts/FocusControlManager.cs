using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FocusControlManager : MonoBehaviour
{
    [SerializeField] GameObject gameObjectInputHandler;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private string targetTag;
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
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == targetTag)
            {
                Debug.Log("Clicked on Entity!");
                // Add your specific action here (e.g., call a method on the hit object)
                // hit.collider.GetComponent<InteractableObject>().Interact(); 
            }
        }
        
    }
}
