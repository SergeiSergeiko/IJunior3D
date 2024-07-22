using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] int _speed;
        [SerializeField] int _followSpeed;
        [SerializeField] Attacker _attacker;
        [SerializeField] GroundFrontDetecter _groundFrontDetecter;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;

        public Vector3 Direction => _direction;

        private void Start()
        {
            _direction = Vector3.right;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_groundFrontDetecter.IsGroundFront() == false)
                ChangeDirection();

            if (_attacker.IsAttack)
                FollowToPlayer();
            else
                Move();
        }

        private void Move()
        {
            _rigidbody.transform.position += _direction * _speed * Time.deltaTime;
        }

        private void FollowToPlayer()
        {
            float positionY = 0;
            float positionX = _attacker.Target.position.x - transform.position.x;
            Vector3 direction = new Vector3(positionX, positionY).normalized;

            if (direction.x < 0 ^ Direction.x < 0)
                ChangeDirection();

            _rigidbody.MovePosition(transform.position + direction * (_followSpeed * Time.fixedDeltaTime));
        }

        private void ChangeDirection()
        {
            int factor = 1;
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -factor;
            transform.localScale = currentScale;

            _direction.x *= -1;
        }
    }
}