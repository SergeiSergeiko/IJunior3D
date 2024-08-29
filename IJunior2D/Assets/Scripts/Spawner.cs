using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : Object
{
    [SerializeField] private T _spawnObject;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
            Spawn(spawnPoint.transform.position);
    }

    private void Spawn(Vector3 position)
    {
        Instantiate(_spawnObject, position, Quaternion.identity);
    }
}