using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public Action Dead;
    public float CurrentHealth { get; private set; }
    public bool IsDead { get; private set; } = false;

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void Heal(float value)
    {
        if (value > 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0f, _maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsDead == false && damage > 0)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0f)
            {
                IsDead = true;
                Dead?.Invoke();
            }
        }
    }
}
