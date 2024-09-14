using Enemies;
using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class LifeDrain : Ability
{
    [SerializeField] private PlayerHealth _owner;
    [SerializeField] private ParticleSystem _effect;

    private Coroutine _draining;

    [field: SerializeField] public float Radius { get; private set; }
    [field: SerializeField] public float DelayDamage { get; private set; }

    private void Start()
    {
        InitParticleSystem();
    }

    private void Update()
    {
        if (Input.GetKeyDown(ActivateButton))
            Activate();

        if (IsActive)
            _effect.transform.position = _owner.transform.position;
    }

    protected override void Activate()
    {
        if (IsActive || CanActivate == false)
            return;

        base.Activate();
        _effect.Play();
        RunCoroutineIfNotRunning(Draining(), _draining);
        CountdownActiveTime();
    }

    private IEnumerator Draining()
    {
        Collider2D[] colliders;
        WaitForSeconds wait = new(DelayDamage);
        
        while (IsActive)
        {
            colliders = Physics2D.OverlapCircleAll(_owner.transform.position, Radius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(Value);
                    _owner.TakeHeal(Value);
                }
            }

            yield return wait;
        }

        _effect.Stop();
        Reload();
    }

    private void InitParticleSystem()
    {
        ShapeModule shapeModule = _effect.shape;
        shapeModule.radius = Radius;
    }

    private void OnDrawGizmos()
    {
        float red = 1f;
        float greed = 0f;
        float blue = 0f;
        float alfa = 0.3f;

        Gizmos.color = new Color(red, greed, blue, alfa);
        Gizmos.DrawSphere(_owner.transform.position, Radius);
    }
}