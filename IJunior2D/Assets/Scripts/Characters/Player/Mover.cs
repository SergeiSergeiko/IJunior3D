using UnityEngine;

namespace MainCharacter
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class Mover : MonoBehaviour
    {
        const string Horizontal = "Horizontal";

        [SerializeField] private float _moveSpeed = 6;
        [SerializeField] private float _jumpForce = 15f;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private bool _isGrounded = true;
        private bool _facingLeft = true;

        private void Start()
        {
            _animator = transform.GetComponent<Animator>();
            _rigidbody = transform.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _isGrounded = IsGrounded();
            Jump();
        }

        private void Update()
        {
            if (Input.GetAxis(Horizontal) == 0)
                Stand();
            else
                Move();
        }

        private void Move()
        {
            float horizontal = Input.GetAxis(Horizontal);

            Vector3 direction = new(horizontal, 0, 0);
            _rigidbody.transform.position += direction * _moveSpeed * Time.deltaTime;

            if (_isGrounded)
                _animator.Play(PlayerAnimatorData.Params.Run);

            LookDirectionTraffic(horizontal);
        }

        private void Jump()
        {
            if (Input.GetKey(KeyCode.W) == false)
                return;

            if (_isGrounded == false)
                return;

            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.Play(PlayerAnimatorData.Params.Jump);
            _isGrounded = false;
        }

        private void Stand()
        {
            if (_isGrounded)
                _animator.Play(PlayerAnimatorData.Params.Idle);
        }

        private void LookDirectionTraffic(float direction)
        {
            int factor = 1;
            float standingSpeed = 0.0f;
            Vector3 currentScale = transform.localScale;

            if (direction < standingSpeed ^ _facingLeft)
            {
                currentScale.x *= -factor;
                _facingLeft = !_facingLeft;
            }

            transform.localScale = currentScale;
        }

        private bool IsGrounded()
        {
            int divider = 2;
            float radius = 0.1f;
            float positionY = transform.position.y - transform.localScale.y / divider;
            Vector3 point = new Vector3(transform.position.x, positionY, 0);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius);

            foreach (Collider2D collider in colliders)
                if (collider.TryGetComponent(out Ground _))
                    return true;

            return false;
        }
    }
}