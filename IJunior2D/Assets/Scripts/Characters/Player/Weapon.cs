using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private int _damage;

    private CircleCollider2D _circleCollider;

    public int Damage { get; private set; }

    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        Damage = _damage;
    }

    private void Update()
    {
        if (_attacker.IsAttack)
            _circleCollider.enabled = true;
        else
            _circleCollider.enabled = false;
    }
}