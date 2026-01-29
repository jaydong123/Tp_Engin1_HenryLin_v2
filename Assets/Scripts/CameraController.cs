using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform player;
    
    [Header("Camera Settings")]
    [SerializeField] GameObject gameObjectInputHandler;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Vector3 offset = new Vector3(0,5,-10);
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed = 10f;
    
    [SerializeField] private FocusControlManager.Focus _focus;
    [SerializeField] private bool isFocus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        if (!_inputHandler)
            _inputHandler = gameObjectInputHandler.GetComponent<InputHandler>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isFocus)
            MoveCamera();
        else 
            UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, offset.y, offset.z), Time.deltaTime * speed);
    }

    private void MoveCamera()
    {
        //only when camera is the focus
        transform.position += moveDirection * (speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        FocusControlManager.OnFocusChanged += OnFocus;
    }
    
    private void OnFocus(FocusControlManager.Focus focus)
    {
        Debug.Log("OnFocus inside CameraController");
        if (focus == _focus)
            SubscribeInput();
        else
            UnsubscribeInput();
    }
    
    private void SubscribeInput()
    {
        Debug.Log("Camera Input Subscribe");
        isFocus = true;
        _inputHandler.OnCameraMoveInput += OnCameraMoveController;
    }    
    
    private void UnsubscribeInput()
    {
        Debug.Log("Camera Input Unsubscribe");
        isFocus = false;
        _inputHandler.OnCameraMoveInput -= OnCameraMoveController;
    }
    
    private void OnDisable()
    {
        FocusControlManager.OnFocusChanged -= OnFocus;
        _inputHandler.OnCameraMoveInput -= OnCameraMoveController;
    }

    private void OnCameraMoveController(Vector2 input)
    {
        //only if it on focus
        Debug.Log("Camera Move Input");
        moveDirection = new Vector3(input.x, 0, 0);
    }
    
}
