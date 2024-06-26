using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new SpawnPoint[transform.childCount];
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        foreach (SpawnPoint spawnPoint in _spawnPoints)
            Spawn(spawnPoint.transform.position);
    }

    private void Spawn(Vector3 position)
    {
        Instantiate(_prefab, position, Quaternion.identity);
    }
}