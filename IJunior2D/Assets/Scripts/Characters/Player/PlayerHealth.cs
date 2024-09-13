using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private Player _owner;
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
        Destroy(_owner.gameObject);
    }
}