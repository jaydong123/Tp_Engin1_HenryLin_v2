using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField][Range(-20,0)] private float offsetZ = -10;
    [SerializeField][Range(-20,0)] private float xDeadZone = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float xOffSet = transform.position.x - player.transform.position.x;
        if (Mathf.Abs(xOffSet) > xDeadZone)
        {
            float direction = Mathf.Sign(xOffSet);
            
            
        }
        transform.position = player.transform.position + new Vector3(0, 5, -15);
    }
}
