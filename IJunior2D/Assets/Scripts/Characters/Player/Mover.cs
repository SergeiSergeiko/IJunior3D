using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 6;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetecter _groundDetecter;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isGrounded = true;
    private bool _facingLeft = true;
    private bool _isJump = false;
    private float _axisDirection;

    private void OnEnable()
    {
        _inputReader.Went += OnMoveHandle;
        _inputReader.Jumped += OnJumpHandle;
    }

    private void OnDisable()
    {
        _inputReader.Went -= OnMoveHandle;
        _inputReader.Jumped -= OnJumpHandle;
    }

    private void Start()
    {
        _animator = transform.GetComponent<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _isGrounded = _groundDetecter.IsGrounded();

        if (_isJump)
            Jump();

        if (_axisDirection != 0)
            Move();
    }

    private void Update()
    {
        Stand();
    }

    private void Move()
    {
        float horizontal = _axisDirection;
        _axisDirection = 0;

        Vector3 direction = new(horizontal, 0, 0);
        _rigidbody.transform.position += direction * _moveSpeed * Time.deltaTime;

        if (_isGrounded)
            _animator.Play(PlayerAnimatorData.Params.Run);

        LookDirectionTraffic(horizontal);
    }

    private void Jump()
    {
        if (_isGrounded == false)
            return;

        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.Play(PlayerAnimatorData.Params.Jump);
        _isGrounded = false;
        _isJump = false;
    }

    private void Stand()
    {
        if (_isGrounded && _axisDirection == 0)
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

    private void OnJumpHandle()
    {
        _isJump = true;
    }

    private void OnMoveHandle()
    {
        _axisDirection = _inputReader.GetAxisDirection();
    }
}