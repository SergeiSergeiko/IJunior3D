using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected int _damage;
        [SerializeField] protected EnemyHealth _health;

        public int Damage { get; protected set; }

        public void TakeDamage(int damage) => _health.TakeDamage(damage);
    }
}