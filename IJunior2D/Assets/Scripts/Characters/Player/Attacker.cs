using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Animator _animator;

    private bool _isAttack;

    private void OnEnable()
    {
        _inputReader.Attacked += OnAttackHandle;
    }

    private void OnDisable()
    {
        _inputReader.Attacked -= OnAttackHandle;
    }

    private void Update()
    {
        if (_isAttack)
            Attack();
    }

    private void Attack()
    {
        _animator.Play(PlayerAnimatorData.Params.Attack);
        _isAttack = false;
    }

    private void OnAttackHandle()
    {
        _isAttack = true;
    }
}