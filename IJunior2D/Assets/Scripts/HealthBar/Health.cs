using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> Changed;
    public event Action Died;

    [field: SerializeField] public int MaxValue { get; private set; }
    public int Value { get; private set; }

    protected void Start()
    {
        TakeHeal(MaxValue);
    }

    public void TakeDamage(int damage)
    {
        SetValue(Value - damage);

        if (Value <= 0)
            Die();
    }

    public void TakeHeal(int value)
    {
        SetValue(Value + value);
    }

    protected virtual void Die()
    {
        Died?.Invoke();
    }

    private void SetValue(int value)
    {
        Value = Mathf.Clamp(value, 0, MaxValue);
        Changed?.Invoke(Value);
    }
}