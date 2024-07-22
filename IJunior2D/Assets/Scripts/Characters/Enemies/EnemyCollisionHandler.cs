using System;
using UnityEngine;

namespace Enemies
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        public event Action<int> DamageReceived;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Weapon weapon))
                DamageReceived?.Invoke(weapon.Damage);
        }
    }
}