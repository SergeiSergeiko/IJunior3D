using UnityEngine;

[RequireComponent(typeof(Movement), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] ScoreDisplay _scoreDisplay;
    [SerializeField] HealthBar _healthBar;
    [SerializeField] int _maxHealth;

    private int _health;
    private int _coins;
    private Animator _animator;

    public int Health
    {
        get
        {
            return _health;
        }

        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            _healthBar.Refresh(Health);

            if (_health <= 0)
            {
                Die();
            }
        }
    }
    public int Coins
    {
        get
        {
            return _coins;
        }

        private set
        {
            _coins = Mathf.Clamp(value, 0, int.MaxValue);
            _scoreDisplay.Refresh(Coins);
        }
    }

    private void Start()
    {
        Coins = 0;
        Health = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin _))
            Coins++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy _))
            TakeDamage();
    }

    public void TakeDamage()
    {
        Health--;
    }

    private void Die()
    {
        _animator.Play("Die");
    }
}