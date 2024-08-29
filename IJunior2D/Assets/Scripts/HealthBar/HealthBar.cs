using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected int MaxValue;

    protected void OnEnable()
    {
        MaxValue = Health.MaxValue;
        Health.Changed += OnValueChanged;
    }

    protected void OnDisable()
    {
        Health.Changed -= OnValueChanged;
    }

    protected void Start()
    {
        OnValueChanged(MaxValue);
    }

    protected virtual void OnValueChanged(int value) { }
}