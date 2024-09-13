using UnityEngine;
using UnityEngine.UI;

public class AbilityActionTimeShower :  MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _ability.ActionTime += ShowActionTime;
    }

    private void OnDisable()
    {
        _ability.ActionTime -= ShowActionTime;
    }

    private void Start()
    {
        _slider.value = 0f;
    }

    private void ShowActionTime(float value)
    {
        _slider.value = value;
    }
}