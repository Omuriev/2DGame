using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public Action Dead;
    public Action<float, float> ChangedHealth;

    public float CurrentHealth { get; private set; }
    public bool IsDead { get; private set; } = false;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        SetHealth(_maxHealth);
        ChangedHealth?.Invoke(CurrentHealth, _maxHealth);
    }

    public void Heal(float value)
    {
        if (value > 0 && IsDead == false)
        {
            SetHealth(CurrentHealth + value);
            ChangedHealth?.Invoke(CurrentHealth, _maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsDead == false && damage > 0)
        {
            SetHealth(CurrentHealth - damage);
            ChangedHealth?.Invoke(CurrentHealth, _maxHealth);

            if (CurrentHealth <= 0f)
            {
                IsDead = true;
                Dead?.Invoke();
            }
        }
    }

    private void SetHealth(float value)
    {
        CurrentHealth = Mathf.Clamp(value, 0, _maxHealth);
    }
}
