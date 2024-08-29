using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private bool _smoothHealEnable;

    private Coroutine _smoothChangeValue;

    private new void Start()
    {
        _slider.maxValue = MaxValue;
        base.Start();
    }

    protected override void OnValueChanged(int value)
    { 
        if (_slider.value < value ^ _smoothHealEnable)
            _slider.value = value;
        else
            StartSmoothChangeValue(value);
    }

    private IEnumerator SmoothChangingValue(int value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _smoothSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void StartSmoothChangeValue(int value)
    {
        if (_smoothChangeValue != null)
            StopCoroutine(_smoothChangeValue);

        _smoothChangeValue = StartCoroutine(SmoothChangingValue(value));
    }
}