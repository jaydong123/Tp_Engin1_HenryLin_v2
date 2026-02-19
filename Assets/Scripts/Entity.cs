using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Reference")]
    //[SerializeField] protected GameObject gameObjectInputHandler;
    protected InputHandler inputHandler => GameManager.Instance.inputHandler;
    
    protected EntityData entityData => GameManager.Instance.entityData;

    public enum Fraction
    {
        Player,
        Enemy,
    }
    
    public Fraction fraction;
    
    protected abstract void OnFocus(Entity focus);
    protected abstract void SubscribeInput();
    protected abstract void UnsubscribeInput();
    
    
}
