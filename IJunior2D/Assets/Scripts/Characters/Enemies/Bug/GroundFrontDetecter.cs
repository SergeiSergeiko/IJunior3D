using UnityEngine;

namespace Enemies
{
    public class GroundFrontDetecter : MonoBehaviour
    {
        [SerializeField] private Bug _bug;
        [SerializeField] private float _radius = 0.1f;

        private Vector3 _position;

        public bool IsGroundFront()
        {
            _position = GetPointPosition();

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_position, _radius);

            foreach (Collider2D collider in colliders)
                if (collider.TryGetComponent(out Ground _))
                    return true;

            return false;
        }

        private Vector3 GetPointPosition()
        {
            int divider = 2;
            float positionX = _bug.transform.position.x + _bug.transform.localScale.x / divider;
            float positionY = _bug.transform.position.y - _bug.transform.localScale.y / divider;

            return new Vector3(positionX, positionY, 0);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_position, _radius);
        }
    }
}