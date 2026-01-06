using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector2 mousePosition;
    private Rigidbody rb;
    private PlayerInputHandler playerInputHandler;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 rotateDirection;
    [SerializeField] private float rotateSpeed = 5.0f;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position += (moveDirection * (speed * Time.deltaTime));
    }

    public void Move(Vector2 input)
    {
        Debug.Log("Im at Move");
        input.Normalize();
        moveDirection = new Vector3(input.x, 0, input.y);
    }
    
    
    public void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Force);
    }

    public void Rotate(Vector2 input)
    {
        Debug.Log("Im at Rotate");
        mousePosition = input;
        Vector3 worldPosition =  cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, cam.nearClipPlane));
        rotateDirection = (worldPosition - transform.position).normalized;
        rotateDirection.z = 0;
        
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
