using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Mover), typeof(Attacker), typeof(EnemyHealth))]
    public class Bug : Enemy
    {
        private void Start()
        {
            Damage = _damage;
        }
    }
}