using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayAudio);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayAudio);
    }

    public void PlayAudio()
    {
        _audio.PlayOneShot(_audio.clip);
    }
}