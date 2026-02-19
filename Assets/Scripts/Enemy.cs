using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private BoxCollider playerBoxCollider;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider hitEntityCollider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (!animationHandler)
            animationHandler = GetComponent<AnimationHandler>();
        if (!hitEntityCollider)
            hitEntityCollider = GetComponent<BoxCollider>();

        fraction = Fraction.Enemy;
        transform.rotation = new  Quaternion(0, 180, 0, 0);
    }
    
    
    
    
    protected override void OnFocus(Entity focus)
    {
        throw new System.NotImplementedException();
    }

    protected override void SubscribeInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void UnsubscribeInput()
    {
        throw new System.NotImplementedException();
    }
}
