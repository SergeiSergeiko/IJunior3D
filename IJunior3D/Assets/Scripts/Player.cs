using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private int _speed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(Horizontal);
        float vertical = Input.GetAxis(Vertical);
        Vector3 direction = new(horizontal, 0, vertical);

        _rigidbody.transform.position += direction * _speed * Time.deltaTime;
    }
}