using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action CoinPickUp;
    public event Action DamageReceived;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy _))
        {
            DamageReceived?.Invoke();
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            CoinPickUp?.Invoke();
            coin.Remove();
        }
    }
}