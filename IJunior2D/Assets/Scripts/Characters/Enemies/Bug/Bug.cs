using UnityEngine;

namespace Enemies
{
    public class Bug : Enemy
    {
        private void Start()
        {
            Damage = _damage;
        }
    }
}