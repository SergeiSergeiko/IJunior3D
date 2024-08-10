using UnityEngine;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    [SerializeField] private AudioSlider _master;
    [SerializeField] private Toggle _toggle;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleSound);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleSound);
    }

    private void ToggleSound(bool enable)
    {
        if (enable)
            _master.Mute();
        else
            _master.Unmute();
    }
}