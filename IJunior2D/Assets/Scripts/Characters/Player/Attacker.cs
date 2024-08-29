using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _reloadTime;

    private Coroutine _reloading;
    private bool _canAttack;

    public bool IsAttack { get; private set; }

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
        if (_canAttack)
            Attack();
    }

    private void Attack()
    {
        _canAttack = false;
        IsAttack = true;
        _animator.Play(PlayerAnimatorData.Params.Attack);
        StartReloading();
    }

    private void StartReloading()
    {
        if (_reloading != null)
            StopCoroutine(Reloading());

        _reloading = StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        WaitForSeconds wait = new(_reloadTime);

        yield return wait;

        IsAttack = false;
    }

    private void OnAttackHandle()
    {
        if (IsAttack == false)
            _canAttack = true;
    }
}