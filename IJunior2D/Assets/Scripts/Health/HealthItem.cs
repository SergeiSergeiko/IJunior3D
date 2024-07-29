using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [field: SerializeField] public int Value { get; private set; }

    public void Remove()
    {
        Destroy(gameObject);
    }
}