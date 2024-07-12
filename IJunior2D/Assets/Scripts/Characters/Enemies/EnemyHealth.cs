using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : Health
    {
        [SerializeField] private CollisionHandler _collisionHandler;

        private void OnEnable()
        {
            _collisionHandler.DamageReceived += TakeDamage;
        }

        private void OnDisable()
        {
            _collisionHandler.DamageReceived -= TakeDamage;
        }
    }
}