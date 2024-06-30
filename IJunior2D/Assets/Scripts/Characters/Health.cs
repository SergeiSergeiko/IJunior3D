using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth;

    private int _health;

    public int CurrentHealth
    {
        get
        {
            return _health;
        }
    }

    private void Start()
    {
        SetHealth(_maxHealth);
    }

    private void SetHealth(int value)
    {
        _health = Mathf.Clamp(value, 0, _maxHealth);
    }
}