using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> Changed;

    [field: SerializeField] public int MaxHealth { get; private set; }
    public int Value { get; private set; }

    protected void Start()
    {
        TakeHealth(MaxHealth);
    }

    protected void TakeDamage(int damage)
    {
        int health = Value - damage;

        TakeHealth(health);
    }

    protected void TakeHealth(int value)
    {
        Value = Mathf.Clamp(Value + value, 0, MaxHealth);
        Changed?.Invoke(Value);
    }
}