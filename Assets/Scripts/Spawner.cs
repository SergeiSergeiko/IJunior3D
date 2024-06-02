using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnpoints;
    [SerializeField] private Enemy _prefab;
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
        Vector3 direction = GetDirectionRandomly();
        Vector3 position = GetSpawnPointRandomly();

        Enemy cube = Instantiate(_prefab, position, Quaternion.identity);
        cube.Init(direction);
    }

    private Vector3 GetDirectionRandomly()
    {
        Vector3[] directions = new[] { Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
        int randomIndex = Random.Range(0, directions.Length);

        return directions[randomIndex];
    }

    private Vector3 GetSpawnPointRandomly()
    {
        int index = Random.Range(0, _spawnpoints.Length);

        return _spawnpoints[index].position;
    }

    private void StartCoroutine(ref Coroutine coroutine, IEnumerator method)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(method);
    }
}