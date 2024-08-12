using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : HealthBar
{
    [SerializeField] protected Slider _slider;

    private new void Start()
    {
        _slider.maxValue = _maxValue;
        base.Start();
    }

    protected override void OnValueChanged(int value) { }
}