using UnityEngine;
using UnityEngine.UI;

public class UIAbilityIcon :  MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _ability.ActionTimeChanged += ActionTimeHandler;
    }

    private void OnDisable()
    {
        _ability.ActionTimeChanged -= ActionTimeHandler;
    }

    private void Start()
    {
        _slider.value = 0f;
    }

    private void ActionTimeHandler(float value)
    {
        _slider.value = value;
    }
}