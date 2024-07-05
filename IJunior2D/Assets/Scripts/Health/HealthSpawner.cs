using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField] private HealthItem _health;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
            Spawn(spawnPoint.transform.position);
    }

    private void Spawn(Vector3 position)
    {
        Instantiate(_health, position, Quaternion.identity);
    }
}