public class FastHealthBar : SliderHealthBar
{
    protected override void OnValueChanged(int value)
    {
        _slider.value = value;
    }
}