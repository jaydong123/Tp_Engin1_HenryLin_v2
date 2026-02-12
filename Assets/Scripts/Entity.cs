using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Reference")]
    //[SerializeField] protected GameObject gameObjectInputHandler;
    protected InputHandler inputHandler => GameManager.Instance.inputHandler;
    
    protected EntityData entityData => GameManager.Instance.entityData;
    protected abstract void OnFocus(Entity focus);
    protected abstract void SubscribeInput();
    protected abstract void UnsubscribeInput();
    
    
}
