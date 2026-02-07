using System;
using System.Net;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Entity
{
    [Header("Reference")]
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

    [SerializeField] private BoxCollider hitEntityCollider;
    private bool IsHitEntityColliderEnabled = false;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem ps;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (!animationHandler)
            animationHandler = GetComponent<AnimationHandler>();
        if (!hitEntityCollider)
            hitEntityCollider = GetComponent<BoxCollider>();
        
    }

    private void Start()
    {
        hitEntityCollider.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        UpdatePosition();
        UpdateAnimation();
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
            UnsubscribeInput();
    }

    protected override void SubscribeInput()
    {
        inputHandler.OnMoveInput += OnMoveController;
        inputHandler.OnJumpInput += OnJumpController;
        inputHandler.OnAttackInput += OnAttackController;
    }    
    
    protected override void UnsubscribeInput()
    {
        moveDirection = Vector3.zero;
        inputHandler.OnMoveInput -= OnMoveController;
        inputHandler.OnJumpInput -= OnJumpController;
        inputHandler.OnAttackInput -= OnAttackController;
    }
    
    private void OnDisable()
    {
        FocusControlManager.OnFocusChanged -= OnFocus;
        inputHandler.OnMoveInput -= OnMoveController;
        inputHandler.OnJumpInput -= OnJumpController;
    }
    

    private void UpdatePosition()
    {
        if (Mathf.Abs(rb.linearVelocity.x) < maxSpeed)
        {
            rb.AddForce(moveDirection * (speed * Time.deltaTime), ForceMode.Impulse);

        }
    }

    private void UpdateAnimation()
    {
        animationHandler.SetSpeed(Mathf.Abs(rb.linearVelocity.x));
    }

    private void OnMoveController(Vector2 input)
    {
        moveDirection = new Vector3(input.x, 0, input.y).normalized;
        if (moveDirection.x > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);

        }
        else if (moveDirection.x < 0) {
        
            transform.rotation = new Quaternion(0, 180, 0, 0);

        }
        //animationHandler.IsWalking();
        //plays animation within blend tree depending on speed
        //animationHandler.SetSpeed(rb.linearVelocity.x);
    }
    
    
    private void OnJumpController()
    {
        if (IsGrounded())
        {
            //Debug.Log("Jump");
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Force);
            animationHandler.IsJumping();
            return;
        }
    }

    private void OnAttackController()
    {
        Debug.Log("On AttackController");
        animationHandler.IsAttacking();
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f, groundLayer);
    }

    public void EnableHitEntityCollider()
    {
        Debug.Log("Enable Hit Entity Collider");
        IsHitEntityColliderEnabled = true;
        hitEntityCollider.enabled = true;
    }
    
    public void DisableHitEntityCollider()
    {
        Debug.Log("Disable Hit Entity Collider");
        IsHitEntityColliderEnabled = false;
        hitEntityCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "Entity" && IsHitEntityColliderEnabled)
        {
            Debug.Log("Bonk");
            DisableHitEntityCollider();
        }
    }
}
