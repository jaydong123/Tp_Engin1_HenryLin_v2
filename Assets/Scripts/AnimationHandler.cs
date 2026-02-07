using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [Header("Hashes")]
    private static readonly int IdleHash = Animator.StringToHash("Idle");
    private static readonly int WalkHash = Animator.StringToHash("Walk");
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(!animator)
            animator = GetComponent<Animator>();
    }

    public void IsIdle()
    {
        animator.SetTrigger(IdleHash);
    }
    public void IsWalking()
    {
        animator.SetTrigger(WalkHash);
    }
    
    public void IsRunning()
    {
        animator.SetTrigger(RunHash);
    }
    
    public void IsJumping()
    {
        animator.SetTrigger(JumpHash);
    }
    public void IsAttacking()
    {
        animator.SetTrigger(AttackHash);
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat(SpeedHash, speed);
    }
    
}
