using System.Collections;
using UnityEngine;

public class SmoothHealthBar : SliderHealthBar
{
    [SerializeField] private float _smoothSpeed;

    private Coroutine _smoothMoving;

    protected override void OnValueChanged(int value)
    {
        StartSmoothMove(value);
    }

    private IEnumerator SmoothMoving(int value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _smoothSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void StartSmoothMove(int value)
    {
        if (_smoothMoving != null)
            StopCoroutine(_smoothMoving);

        _smoothMoving = StartCoroutine(SmoothMoving(value));
    }
}