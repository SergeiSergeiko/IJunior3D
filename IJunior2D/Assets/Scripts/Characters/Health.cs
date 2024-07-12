using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;

    public int Value { get; private set; }

    protected void Start()
    {
        SetHealth(_maxHealth);
    }

    protected void TakeDamage(int damage)
    {
        int health = Value - damage;

        SetHealth(health);
    }

    protected void SetHealth(int value)
    {
        Value = Mathf.Clamp(value, 0, _maxHealth);

        if (Value <= 0)
            Die();
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}