using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : Entity
{
    [Header("Reference")]
    [SerializeField] private Transform player;
    
    [Header("Camera Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0,30,-10);
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed = 10f;
    
    //[SerializeField] private FocusControlManager.Focus _focus;
    [SerializeField] private bool isFocus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Awake()
    {
        base.Awake();
    }
    protected void Start()
    {
        GameManager.Instance.audioHandler.PlayBGM(audioSource);
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
    
    protected override void OnFocus(Entity focus)
    {
        if (this == focus)
            SubscribeInput();
        else
        {
            player =  focus.transform;
            UnsubscribeInput();
        }
    }
    
    protected override void SubscribeInput()
    {
        isFocus = true;
        inputHandler.OnCameraMoveInput += OnCameraMoveController;
    }    
    
    protected override void UnsubscribeInput()
    {
        isFocus = false;
        inputHandler.OnCameraMoveInput -= OnCameraMoveController;
    }
    
    private void OnDisable()
    {
        FocusControlManager.OnFocusChanged -= OnFocus;
        inputHandler.OnCameraMoveInput -= OnCameraMoveController;
    }

    private void OnCameraMoveController(Vector2 input)
    {
        //only if it on focus
        moveDirection = new Vector3(input.x, 0, 0);
    }
    
}
