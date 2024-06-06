using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    private Alarm _alarm;
    private Strobe _strobe;

    private void Start()
    {
        _alarm = GetComponentInChildren<Alarm>();
        _strobe = GetComponentInChildren<Strobe>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _alarm.Play();
            _strobe.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _alarm.Stop();
            _strobe.Stop();
        }
    }
}