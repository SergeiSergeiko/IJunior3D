using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected int _damage;

        public int Damage { get; protected set; }
    }
}