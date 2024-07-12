using System;
using UnityEngine;
using Enemies;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<int> DamageReceived;
    public event Action CoinPickUp;
    public event Action<int> HealthItemPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            DamageReceived?.Invoke(enemy.Damage);
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            CoinPickUp?.Invoke();
            coin.Remove();
        }

        if (collision.TryGetComponent(out HealthItem healthItem))
        {
            HealthItemPickUp?.Invoke(healthItem.Value);
            healthItem.Remove();
        }
    }
}