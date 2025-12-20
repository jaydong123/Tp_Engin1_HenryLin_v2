using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInputHandler playerInputHandler;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 100;
    [SerializeField] private Vector3 moveDirection;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(moveDirection * speed);
    }

    public void Move(Vector2 input)
    {
        input.Normalize();
        moveDirection = new Vector3(input.x, 0, input.y);
    }
    
    
    public void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Force);
    }
}
