using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Bug : Enemy
{
    [SerializeField] int _speed;

    private Rigidbody2D _rigidbody;
    private Vector3 _direction = Vector2.right;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGroundUnder();
        Patroling();
    }

    private void Patroling()
    {
        _rigidbody.transform.position += _direction * _speed * Time.deltaTime;

        Physics2D.OverlapCircleAll(_direction, _speed);
    }

    private void CheckGroundUnder()
    {
        float radius = 0.1f;
        float positionX = transform.position.x + 0.5f * transform.localScale.x;
        float positionY = transform.position.y - 0.5f;
        Vector3 point = new Vector3(positionX, positionY, 0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius);

        foreach (Collider2D collider in colliders)
            if (collider.TryGetComponent(out Ground _))
                return;

        ChangeDirection();
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