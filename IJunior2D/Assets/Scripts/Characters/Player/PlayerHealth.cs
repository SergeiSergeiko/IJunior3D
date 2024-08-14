using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private PlayerCollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _collisionHandler.DamageReceived += TakeDamage;
        _collisionHandler.HealthItemPickUp += TakeHealth;
    }

    private void OnDisable()
    {
        _collisionHandler.DamageReceived -= TakeDamage;
        _collisionHandler.HealthItemPickUp -= TakeHealth;
    }
}