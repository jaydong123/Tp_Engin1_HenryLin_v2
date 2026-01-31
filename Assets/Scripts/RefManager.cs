using UnityEngine;

public class RefManager : MonoBehaviour
{
    public static RefManager Instance;

    public InputHandler inputHandler;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
    }
}
