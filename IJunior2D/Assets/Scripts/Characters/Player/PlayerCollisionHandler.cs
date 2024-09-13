using System;
using UnityEngine;
using Enemies;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<int> DamageReceived;
    public event Action<int> HealthItemPickUp;
    public event Action<int> CoinPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            DamageReceived?.Invoke(enemy.Damage);

        if (collision.TryGetComponent(out Item item))
        {
            if (item is HealthItem healthItem)
            {
                HealthItemPickUp?.Invoke(healthItem.Value);
                healthItem.Remove();
            }

            if (item is Coin coin)
            {
                CoinPickUp?.Invoke(coin.Value);
                coin.Remove();
            }
        }
    }
}