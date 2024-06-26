using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;

    public int Health 
    {
        get
        {
            return _health;
        }

        set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);

            if (_health <= 0)
                Die();
        }
    }

    private void Start()
    {
        Health = _maxHealth;
    }

    protected void TakeDamage(int damage)
    {
        Health -= damage;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}