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
        SetValue(Value - damage);
    }

    protected void TakeHealth(int health)
    {
        SetValue(Value + health);
    }

    private void SetValue(int value)
    {
        Value = Mathf.Clamp(value, 0, MaxHealth);
        Changed?.Invoke(Value);
    }
}