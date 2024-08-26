using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _yPosition = 1.2f;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 position = new Vector3(_target.transform.position.x,
            _target.transform.position.y + _yPosition, 0);

        transform.position = position;
    }
}