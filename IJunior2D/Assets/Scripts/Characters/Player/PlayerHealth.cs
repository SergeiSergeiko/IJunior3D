using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject _target;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _collisionHandler.DamageReceived += TakeDamage;
        _collisionHandler.HealthItemPickUp += TakeHeal;
    }

    private void OnDisable()
    {
        _collisionHandler.DamageReceived -= TakeDamage;
        _collisionHandler.HealthItemPickUp -= TakeHeal;
    }

    protected override void Die()
    {
        base.Die();
        Destroy(_target.gameObject);
    }
}