using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int Value { get; private set; }

    private void Start()
    {
        SetHealth(_maxHealth);
    }

    private void SetHealth(int value)
    {
        Value = Mathf.Clamp(value, 0, _maxHealth);
    }
}