using System;
using UnityEngine;
using UnityEngine.UI;

public class EntityUIHandler : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Slider healthBar;
    private Entity entity;
    
    private void Awake()
    {
        if (!entity)
            entity = GetComponent<Entity>();
        if (!healthBar)
            healthBar = transform.Find("Canvas/HealthBar").GetComponent<Slider>();
    }

    private void Start()
    {
        healthBar.maxValue = entity.maxhealth;
        healthBar.value = entity.CurrentHealth;
    }

    private void OnEnable()
    {
        entity.OnHealthChanged += UpdateHealthBar;
    }    
    
    private void OnDisable()
    {
        entity.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float value)
    {
        healthBar.value = value;
    }

}
