using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform[] _targets;

    public Transform[] GetTargets()
    {
        Transform[] targets = new Transform[_targets.Length];
        _targets.CopyTo(targets, 0);

        return targets;
    }

    public Enemy GetPrefab()
    {
        return _prefab;
    }
}
