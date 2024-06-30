using UnityEngine;
using MainCharacter;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private int _smoothValue = 2;
    [SerializeField] private float _positionY = 1;

    private float _positionZ = -3f;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_target.transform.position.x,
            _target.transform.position.y + _positionY, _positionZ);
        transform.position = Vector3.Lerp(transform.position,
            targetPosition, Time.deltaTime * _smoothValue);
    }
}