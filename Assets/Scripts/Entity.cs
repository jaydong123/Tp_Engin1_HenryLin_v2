using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected abstract void OnFocus(Entity focus);
    protected abstract void SubscribeInput();
    protected abstract void UnsubscribeInput();
}
