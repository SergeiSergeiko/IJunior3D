using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnpoints;
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;
    [SerializeField] private int _delaySpawn;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, _delaySpawn);
    }

    private void Spawn()
    {
        _pool.Get();
    }

    private void ActionOnGet(Cube cube)
    {
        cube.transform.position = GetSpawnPointRandomly();
        cube.gameObject.SetActive(true);
        cube.Died += CubeDied;
    }

    private void CubeDied(Cube cube)
    {
        cube.Died -= CubeDied;
        _pool.Release(cube);
    }

    private Vector3 GetSpawnPointRandomly()
    {
        int index = Random.Range(0, _spawnpoints.Length);

        return _spawnpoints[index].position;
    }
}
