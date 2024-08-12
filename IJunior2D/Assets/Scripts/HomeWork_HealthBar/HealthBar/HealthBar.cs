using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected int _maxValue;

    protected void Start()
    {
        OnValueChanged(_maxValue);
    }

    protected void OnEnable()
    {
        _maxValue = _health.MaxHealth;
        _health.Changed += OnValueChanged;
    }

    protected void OnDisable()
    {
        _health.Changed -= OnValueChanged;
    }

    protected virtual void OnValueChanged(int value) { }
}