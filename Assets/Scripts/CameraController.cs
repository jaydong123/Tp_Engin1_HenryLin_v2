using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform player;
    
    [Header("Camera Settings")]
    [SerializeField] private CameraInputHandler cameraInputHandler;
    [SerializeField] private Vector3 offset = new Vector3(0,5,-10);
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed = 10f;
    
    private FocusControlManager.Focus _focus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        if (!cameraInputHandler)
            cameraInputHandler = GetComponent<CameraInputHandler>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_focus != FocusControlManager.Focus.Camera)
            UpdateCameraPosition();
        else 
            MoveCamera();
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
        // playerInputHandler.OnMoveInput += OnMoveController;
        // playerInputHandler.OnJumpInput += OnJumpController;
    }
    
    private void OnFocus(FocusControlManager.Focus focus)
    {
        _focus = focus;
        if (_focus == FocusControlManager.Focus.Camera)
            SubscribeInput();
        else
            UnsubscribeInput();
    }
    
    private void SubscribeInput()
    {
        Debug.Log("Camera Input Subscribe");
        cameraInputHandler.OnCameraMoveInput += OnCameraMoveController;
    }    
    
    private void UnsubscribeInput()
    {
        Debug.Log("Camera Input Unsubscribe");
        cameraInputHandler.OnCameraMoveInput -= OnCameraMoveController;
    }
    
    private void OnDisable()
    {
        FocusControlManager.OnFocusChanged -= OnFocus;
        cameraInputHandler.OnCameraMoveInput -= OnCameraMoveController;
    }

    private void OnCameraMoveController(Vector2 input)
    {
        Debug.Log("Camera Move Input");
        moveDirection = new Vector3(input.x, 0, 0);
    }
    
}
