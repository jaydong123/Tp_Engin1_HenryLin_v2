using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(!animator)
            animator = GetComponent<Animator>();
    }

    public void IsMoving()
    {
        animator.SetBool("IsDoubleJumping", false);
    }

    public void IsDoubleJumping()
    {
        animator.SetBool("IsDoubleJumping", true);
    }
}
