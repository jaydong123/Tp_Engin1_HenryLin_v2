using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] AnimationHandler animationHandler;
    [SerializeField] BoxCollider playerBoxCollider;
    
    [SerializeField] LayerMask groundLayer;
    
    
    [SerializeField] private Camera cam;
    private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private float moveForce = 200;
    [SerializeField] private Vector3 moveDirection;
    
    [SerializeField] private FocusControlManager.Focus _focus;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (!playerInputHandler)
            playerInputHandler = GetComponent<PlayerInputHandler>();
        if (!animationHandler)
            animationHandler = GetComponent<AnimationHandler>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }

    private void OnEnable()
    {
        FocusControlManager.OnFocusChanged += OnFocus;
        // playerInputHandler.OnMoveInput += OnMoveController;
        // playerInputHandler.OnJumpInput += OnJumpController;
    }

    private void OnFocus(FocusControlManager.Focus focus)
    {
        //_focus = focus;
        if (focus == FocusControlManager.Focus.Player)
            SubscribeInput();
        else
            UnsubscribeInput();
    }

    private void SubscribeInput()
    {
        Debug.Log("Player SUBSCRIBED input");
        playerInputHandler.OnMoveInput += OnMoveController;
        playerInputHandler.OnJumpInput += OnJumpController;
    }    
    
    private void UnsubscribeInput()
    {
        Debug.Log("Player UNSUBSCRIBED input");
        playerInputHandler.OnMoveInput -= OnMoveController;
        playerInputHandler.OnJumpInput -= OnJumpController;
    }
    
    private void OnDisable()
    {
        FocusControlManager.OnFocusChanged -= OnFocus;
        playerInputHandler.OnMoveInput -= OnMoveController;
        playerInputHandler.OnJumpInput -= OnJumpController;
    }
    

    private void UpdatePosition()
    {
        if (Mathf.Abs(rb.linearVelocity.x) < maxSpeed)
        {
            rb.AddForce(moveDirection * (speed * Time.deltaTime), ForceMode.Impulse);

        }
    }

    private void OnMoveController(Vector2 input)
    {
        //Debug.Log(input.ToString()); //why it never called
        moveDirection = new Vector3(input.x, 0, input.y).normalized;
        if (moveDirection.x > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);

        }
        else if (moveDirection.x < 0) {
        
            transform.rotation = new Quaternion(0, 180, 0, 0);

        }

        animationHandler.IsMoving();
    }
    
    
    private void OnJumpController()
    {
        if (IsGrounded())
        {
            //Debug.Log("Jump");
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Force);
            return;
        }
    }
    

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f, groundLayer);
    }
}
