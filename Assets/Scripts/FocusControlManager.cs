using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class FocusControlManager : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    Entity _cameraEntity;

    private InputHandler inputHandler => GameManager.Instance.inputHandler;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private string targetTag;

    [SerializeField] private Entity _focus;

    private void Awake()
    {
        if (!_cameraEntity)
            _cameraEntity = _camera.gameObject.GetComponent<Entity>();
    }

    private void Start()
    {
        currentFocus = _cameraEntity;
        
    }
    
    private void OnEnable()
    {
        inputHandler.OnMouseInput += SetFocusByMouseInput;
    }    
    
    private void OnDisable()
    {
        inputHandler.OnMouseInput -= SetFocusByMouseInput;
    }
    public static event Action<Entity> OnFocusChanged;
    public Entity currentFocus
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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Debug.Log("SetFocusByMouseInput");
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == targetTag)
            {
                currentFocus = hit.collider.gameObject.GetComponent<Entity>();
                return;
            }
        }
        currentFocus = _camera.gameObject.GetComponent<Entity>();
        
    }
}
