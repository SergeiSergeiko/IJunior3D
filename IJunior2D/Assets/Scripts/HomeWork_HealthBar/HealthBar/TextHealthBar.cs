using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TMP_Text _text;

    protected override void OnValueChanged(int value)
    {
        _text.text = $"{value}/{_maxValue}";
    }
}