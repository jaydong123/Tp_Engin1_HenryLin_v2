using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private BoxCollider playerBoxCollider;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider hitEntityCollider;
    [SerializeField] private EntityUIHandler entityUIHandler;
    [SerializeField] private Entity target;
    private float distanceBetweenObjects;

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
    
    private void FindPlayer()
    {
        target = GameManager.Instance.listOfAllPlayerEntity[Random.Range(0, GameManager.Instance.listOfAllPlayerEntity.Count)];
    }

    private void GoToTarget()
    {
        if (target != null)
        {
            distanceBetweenObjects = Vector3.Distance(transform.position, target.transform.position);
            if (distanceBetweenObjects > 3f)
            {
                
            }
        }

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
