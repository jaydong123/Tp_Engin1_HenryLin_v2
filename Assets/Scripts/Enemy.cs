using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private BoxCollider playerBoxCollider;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider hitEntityCollider;
    [SerializeField] private EntityUIHandler entityUIHandler;
    
    private void Awake()
    {
        if (!rb)
            rb = GetComponent<Rigidbody>();
        if (!animationHandler)
            animationHandler = GetComponent<AnimationHandler>();
        if (!hitEntityCollider)
            hitEntityCollider = GetComponent<BoxCollider>();
        if (!entityUIHandler)
            entityUIHandler = GetComponent<EntityUIHandler>();

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
