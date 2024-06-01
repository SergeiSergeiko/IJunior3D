using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;

    public void Init(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;
    }

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
        _rigidbody.AddForce(_speed * Time.deltaTime * _moveDirection, ForceMode.Acceleration);
    }
}