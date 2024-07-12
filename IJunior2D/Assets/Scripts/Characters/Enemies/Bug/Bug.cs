using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Bug : Enemy
    {
        [SerializeField] int _speed;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction = Vector2.right;

        private void Start()
        {
            Damage = _damage;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Patroling();
        }

        private void Patroling()
        {
            if (IsGroundFront() == false)
                ChangeDirection();

            Move();
        }

        private void Move()
        {
            _rigidbody.transform.position += _direction * _speed * Time.deltaTime;
        }

        private bool IsGroundFront()
        {
            int divider = 2;
            float radius = 0.1f;
            float positionX = transform.position.x + transform.localScale.x / divider;
            float positionY = transform.position.y - transform.localScale.y / divider;
            Vector3 point = new Vector3(positionX, positionY, 0);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius);

            foreach (Collider2D collider in colliders)
                if (collider.TryGetComponent(out Ground _))
                    return true;

            return false;
        }

        private void ChangeDirection()
        {
            int factor = 1;
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -factor;
            transform.localScale = currentScale;

            _direction.x *= -1;
        }

        private void OnDrawGizmos()
        {
            float radius = 0.1f;
            float positionX = transform.position.x + 0.5f * transform.localScale.x;
            float positionY = transform.position.y - 0.5f;
            Vector3 point = new Vector3(positionX, positionY, 0);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(point, radius);
        }
    }
}