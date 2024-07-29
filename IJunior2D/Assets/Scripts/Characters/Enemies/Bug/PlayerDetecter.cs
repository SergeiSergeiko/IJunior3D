using System;
using UnityEngine;

namespace Enemies
{
    public class PlayerDetecter : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private float _raycastDistance = 10f;
        [SerializeField] private LayerMask _layerMask;

        public event Action<Transform> Spotted;

        private void FixedUpdate()
        {
            ScanFront();
        }

        private void ScanFront()
        {
            Vector3 direction = _mover.Direction;

            Debug.DrawRay(transform.position, direction * _raycastDistance, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,
                _raycastDistance, _layerMask);
            
            if (hit.collider != null && hit.collider.TryGetComponent(out Player player))
                Spotted?.Invoke(player.transform);
        }
    }
}