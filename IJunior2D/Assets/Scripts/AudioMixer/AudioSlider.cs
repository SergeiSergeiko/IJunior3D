using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private AudioMixerGroup _audioGroup;
    [SerializeField] private Slider _slider;

    private string _volumeKey;
    private bool _isMuted;
    private float _minValue = 0.0001f;
    private float _maxValue = 1f;

    private void Start()
    {
        _volumeKey = $"{_name}Volume";
        _slider.minValue = _minValue;
        _slider.maxValue = _maxValue;
        _slider.onValueChanged?.Invoke(_slider.value);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    public void Mute()
    {
        PlayerPrefs.SetFloat(_volumeKey, _slider.value);
        SetVolume(_minValue);
        _isMuted = true;
    }

    public void Unmute()
    {
        _isMuted = false;
        SetVolume(PlayerPrefs.GetFloat(_volumeKey));
    }

    private void SetVolume(float volume)
    {
        if (_isMuted)
        {
            PlayerPrefs.SetFloat(_volumeKey, _slider.value);
            return;
        }

        float value = GetDbFromFloat(volume);

        _audioGroup.audioMixer.SetFloat(_name, value);
    }

    private float GetDbFromFloat(float volume)
    {
        float factor = 20;

        return Mathf.Log10(volume) * factor;
    }
}