using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : Health
    {
        [SerializeField] private Enemy _owner;
        [SerializeField] private ParticleSystem _dieEffect;
        [SerializeField] private EnemyCollisionHandler _collisionHandler;

        private void OnEnable()
        {
            _collisionHandler.DamageReceived += TakeDamage;
        }

        private void OnDisable()
        {
            _collisionHandler.DamageReceived -= TakeDamage;
        }

        protected override void Die()
        {
            base.Die();
            Instantiate(_dieEffect, transform.position, Quaternion.identity);
            Destroy(_owner.gameObject);
        }
    }
}