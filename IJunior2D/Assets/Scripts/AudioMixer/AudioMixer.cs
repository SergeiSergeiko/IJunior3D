using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    private const string ToggleSound = "ToggleSound";
    private const string Master = "Master";
    private const string Buttons = "Buttons";
    private const string Music = "Music";

    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Toggle _toggleSound;
    [SerializeField] private Slider _master;
    [SerializeField] private Slider _buttons;
    [SerializeField] private Slider _background;
    
    private void Start()
    {
        _master.value = PlayerPrefs.GetFloat(Master);
        _buttons.value = PlayerPrefs.GetFloat(Buttons);
        _background.value = PlayerPrefs.GetFloat(Music);
        _toggleSound.isOn = PlayerPrefs.GetInt(ToggleSound) == 1;
    }
    
    public void ToggleVolume(bool enable)
    {
        float minValue = 0.0001f;
        
        if (enable)
            _mixerGroup.audioMixer.SetFloat(Master, FloatVolumeToDb(minValue));
        else
            SetMasterVolume(PlayerPrefs.GetFloat(Master));

        PlayerPrefs.SetInt(ToggleSound, enable ? 1 : 0);
    }

    public void SetMasterVolume(float value)
    {
        SetVolume(Master, value);
    }

    public void SetButtonsVolume(float value)
    {
        SetVolume(Buttons, value);
    }

    public void SetBackgroundVolume(float value)
    {
        SetVolume(Music, value);
    }

    private void SetVolume(string name, float volume)
    {
        float value = FloatVolumeToDb(volume);
        
        _mixerGroup.audioMixer.SetFloat(name, value);
        PlayerPrefs.SetFloat(name, volume);
    }

    private float FloatVolumeToDb(float volume)
    {
        float factor = 20;

        return Mathf.Log10(volume) * factor;
    }
}