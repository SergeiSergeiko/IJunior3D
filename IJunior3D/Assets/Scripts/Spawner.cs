using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _delaySpawn;

    private Coroutine _spawnRepeating;

    private void Start()
    {
        StartCoroutine(ref _spawnRepeating, SpawnRepeating());
    }

    private IEnumerator SpawnRepeating()
    {
        WaitForSeconds wait = new(_delaySpawn);

        while (true)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        SpawnPoint spawnPoint = GetSpawnPointRandomly();
        Enemy prefab = spawnPoint.GetPrefab();
        Transform[] targets = spawnPoint.GetTargets();
        Vector3 position = spawnPoint.GetComponent<Transform>().position;

        Enemy cube = Instantiate(prefab, position, Quaternion.identity);
        cube.Init(targets);
    }

    private SpawnPoint GetSpawnPointRandomly()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        return _spawnPoints[index];
    }

    private void StartCoroutine(ref Coroutine coroutine, IEnumerator method)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(method);
    }
}