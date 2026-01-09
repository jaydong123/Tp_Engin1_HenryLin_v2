using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector2 mousePosition;
    private Rigidbody rb;
    private PlayerInputHandler playerInputHandler;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 200;
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
        moveDirection = new Vector3(input.x, 0, 0);
    }
    
    
    public void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Force);
    }

    public void Rotate(Vector2 input)
    {
        Ray ray = cam.ScreenPointToRay(input);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float hit))
        {
            Vector3 worldPosition = ray.GetPoint(hit);
            rotateDirection = worldPosition - transform.position.normalized;
            rotateDirection.y = 0;
        }

        if (rotateDirection.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(rotateDirection, Vector3.up),
                rotateSpeed * Time.deltaTime
            );
        }
    }
}
