using System;
using UnityEngine;

namespace Enemies
{
    public class CollisionHandler : MonoBehaviour
    {
        public event Action<int> DamageReceived;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Weapon weapon))
            {
                DamageReceived?.Invoke(weapon.Damage);
            }
        }
    }
}