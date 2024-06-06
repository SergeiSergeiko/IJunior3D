using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _rateChange;

    private AudioSource _sound;
    private Coroutine _volumeChanging;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = _minVolume;
    }

    public void Play()
    {
        StartVolumeChanging(_maxVolume);
    }

    public void Stop()
    {
        StartVolumeChanging(_minVolume);
    }

    private IEnumerator VolumeChanging(float targetValue)
    {
        if (_sound.isPlaying == false)
            _sound.Play();

        while (_sound.volume != targetValue)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, targetValue, _rateChange * Time.deltaTime);

            yield return null;
        }

        if (_sound.volume <= 0f)
            _sound.Stop();
    }

    private void StartVolumeChanging(float targetValue)
    {
        if (_volumeChanging != null)
            StopCoroutine(_volumeChanging);

        _volumeChanging = StartCoroutine(VolumeChanging(targetValue));
    }
}