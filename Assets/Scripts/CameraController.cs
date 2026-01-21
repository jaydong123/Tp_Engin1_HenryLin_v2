using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Header("Reference")]
    [SerializeField] private Vector3 offset = new Vector3(0,5,-10);
    [SerializeField] private float speed = 10f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, offset.y, offset.z), Time.deltaTime * speed);
    }
}
