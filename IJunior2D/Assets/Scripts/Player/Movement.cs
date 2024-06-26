using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D), typeof(Animator))]
public class Movement : MonoBehaviour
{
    const string Horizontal = "Horizontal";

    [SerializeField] private float _moveSpeed = 6;
    [SerializeField] private float _jumpForce = 15f;

    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _capsulleCollider;
    private Animator _animator;
    private bool _isGrounded = true;
    private bool _facingLeft = true;

    private void Start()
    {
        _capsulleCollider = transform.GetComponent<CapsuleCollider2D>();
        _animator = transform.GetComponent<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGroundUnder();
        Jump();
    }

    private void Update()
    {
        if (Input.GetAxis(Horizontal) == 0)
            Stand();
        else
            Move();

        Attack();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(Horizontal);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        Vector3 direction = new(horizontal, 0, 0);
        _rigidbody.transform.position += direction * _moveSpeed * Time.deltaTime;

        if (_isGrounded)
            _animator.Play("Run");

        LookDirectionTraffic(horizontal);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.W) == false)
            return;

        if (_isGrounded == false)
            return;

        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.Play("Jump");
        _isGrounded = false;
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) == false)
            return;

        _animator.Play("Attack");
    }

    private void Stand()
    {
        if (_isGrounded)
            _animator.Play("Idle");
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

    private void CheckGroundUnder()
    {
        float radius = 0.1f;
        float downPosition = transform.position.y - 0.5f;
        Vector3 point = new Vector3(transform.position.x, downPosition, 0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius);

        foreach (Collider2D collider in colliders)
            if (collider.TryGetComponent(out Ground _))
                _isGrounded = true;
    }
}