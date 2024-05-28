using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent (typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _minLifeTime;
    [SerializeField] private int _maxLifeTime;

    private Renderer _renderer;
    private Color _defualtColor;
    private bool _isTouched;

    public event Action<Cube> Died;

    private void OnValidate()
    {
        if (_minLifeTime >= _maxLifeTime)
            _maxLifeTime = _minLifeTime + 1;
    }

    private void OnDisable()
    {
        _renderer.material.color = _defualtColor;
        _isTouched = false;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defualtColor = _renderer.material.color;
    }

    public void Touch()
    {
        if (_isTouched)
            return;

        int lifeTime = Random.Range(_minLifeTime, _maxLifeTime);

        _isTouched = true;
        ChangeColorRandomly();
        StartLifeTimer(lifeTime);
    }

    private void StartLifeTimer(int lifeTime)
    {
        Invoke(nameof(Die), lifeTime);
    }

    private void Die()
    {
        Died?.Invoke(this);
    }

    private void ChangeColorRandomly()
    {
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);

        _renderer.material.color = new Color(red, green, blue);
    }
}