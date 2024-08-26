using UnityEngine;

public class HealthBar : MonoBehaviour

{
    [SerializeField] protected Health _health;

    protected int _MaxValue;

    protected void OnEnable()
    {
        _MaxValue = _health.MaxHealth;
        _health.Changed += OnValueChanged;
    }

    protected void OnDisable()
    {
        _health.Changed -= OnValueChanged;
    }

    protected void Start()
    {
        OnValueChanged(_MaxValue);
    }

    protected virtual void OnValueChanged(int value) { }
}