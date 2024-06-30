using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
            Spawn(spawnPoint.transform.position);
    }

    private void Spawn(Vector3 position)
    {
        Instantiate(_coin, position, Quaternion.identity);
    }
}