using System;
using UnityEngine;
using Enemies;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<int> DamageReceived;
    public event Action<int> HealthItemPickUp;
    public event Action CoinPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            DamageReceived?.Invoke(enemy.Damage);

        if (collision.TryGetComponent(out HealthItem healthItem))
        {
            HealthItemPickUp?.Invoke(healthItem.Value);
            healthItem.Remove();
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            CoinPickUp?.Invoke();
            coin.Remove();
        }
    }

    public void TakeDamage(int damage)
    {
        DamageReceived?.Invoke(damage);
    }

    public void TakeHealth(int health)
    {
        HealthItemPickUp?.Invoke(health);
    }
}