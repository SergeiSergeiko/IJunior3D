using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Transform[] _targets;
    private int _currentIndexTarget;

    public void Init(Transform[] target)
    {
        _targets = target;
        _currentIndexTarget = 0;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_currentIndexTarget >= 0)
        {
            Move(_targets[_currentIndexTarget]);

            if (Vector3.Distance(transform.position, _targets[_currentIndexTarget].position) < 1f)
                ChangeTarget();
        }
    }

    private void Move(Transform target)
    {
        _rigidbody.position = Vector3.MoveTowards(transform.position, _targets[_currentIndexTarget].position, _speed * Time.deltaTime);
    }

    private void ChangeTarget()
    {
        if (_currentIndexTarget == _targets.Length - 1)
            Die();

        _currentIndexTarget = (_currentIndexTarget + 1) % _targets.Length;
    }

    private void Die() => Destroy(gameObject);
}