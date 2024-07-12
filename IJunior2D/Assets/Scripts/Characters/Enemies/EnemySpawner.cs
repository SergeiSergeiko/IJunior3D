using UnityEngine;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private SpawnPoint[] _spawnPoints;

        private void Start()
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
                Spawn(spawnPoint.transform.position);
        }

        private void Spawn(Vector3 position)
        {
            Instantiate(_enemy, position, Quaternion.identity);
        }
    }
}