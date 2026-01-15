using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] AnimationHandler animationHandler;
    
    [SerializeField] LayerMask groundLayer;
    
    
    [SerializeField] private Camera cam;
    private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private float moveForce = 200;
    [SerializeField] private Vector3 moveDirection;
    
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
        playerInputHandler.OnMoveInput += OnMoveController;
        playerInputHandler.OnJumpInput += OnJumpController;
    }

    private void OnDisable()
    {
        playerInputHandler.OnMoveInput -= OnMoveController;
        playerInputHandler.OnJumpInput -= OnJumpController;
        
    }
    

    private void UpdatePosition()
    {
        //rb.AddForce(moveDirection * (speed * moveForce));
        transform.position += (moveDirection * (speed * Time.deltaTime));
    }

    private void OnMoveController(Vector2 input)
    {
        //Debug.Log("Im at Move");
        //input.Normalize();
        moveDirection = new Vector3(input.x, 0, 0);
        animationHandler.IsMoving();
    }
    
    
    private void OnJumpController()
    {
        if (IsGrounded())
        {
            Debug.Log("Jump");
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Force);
            return;
        }
    }
    

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f, groundLayer);
    }
}
