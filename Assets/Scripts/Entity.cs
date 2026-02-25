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
    
    
    public float maxhealth = 100;
    [SerializeField] protected float health;
    public event Action<float> OnHealthChanged;
    public Fraction fraction;

    protected void Start()
    {
        SetMaxHealth(maxhealth);
    }

    public float CurrentHealth
    {
        get => health;
        set
        {
            health = value;
            OnHealthChanged?.Invoke(health);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
            Die();
    }
    
    protected abstract void OnFocus(Entity focus);
    protected abstract void SubscribeInput();
    protected abstract void UnsubscribeInput();

    protected virtual void Die()
    {
        Destroy(gameObject, 1f);
    }
    protected void SetMaxHealth(float value)
    {
        health = value;
    }
    
    [ContextMenu("SetHealth")]
    public void SetHealth()
    {
        CurrentHealth = health;   
    }
}
