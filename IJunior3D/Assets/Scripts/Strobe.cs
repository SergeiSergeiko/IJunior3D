using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Strobe : MonoBehaviour
{
    [SerializeField] private Color _firstColor;
    [SerializeField] private Color _secondColor;
    [SerializeField] private float _delay;
    
    private Color _defaultColor;
    private Renderer _renderer;
    private Coroutine _flashing;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    private void OnDisable()
    {
        if (_flashing != null)
            StopCoroutine(_flashing);
    }

    public void Play()
    {
        StartFlashing();
    }

    public void Stop()
    {
        StopCoroutine(_flashing);
        _renderer.material.color = _defaultColor;
    }

    private IEnumerator Flashing()
    {
        WaitForSeconds wait = new(_delay);

        while (true)
        {
            ChangeColor();

            yield return wait;
        }
    }

    private void ChangeColor()
    {
        if (_renderer.material.color == _firstColor)
            _renderer.material.color = _secondColor;
        else
            _renderer.material.color = _firstColor;
    }

    private void StartFlashing()
    {
        if (_flashing != null)
            StopCoroutine(_flashing);

        _flashing = StartCoroutine(Flashing());
    }
}