using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> Changed;

    [field: SerializeField] public int MaxHealth { get; private set; }
    public int Value { get; private set; }

    protected void Start()
    {
        SetHealth(MaxHealth);
    }

    protected void TakeDamage(int damage)
    {
        int health = Value - damage;

        SetHealth(health);
    }

    protected void SetHealth(int value)
    {
        Value = Mathf.Clamp(value, 0, MaxHealth);
        Changed?.Invoke(Value);

        if (Value <= 0)
            Die();
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}