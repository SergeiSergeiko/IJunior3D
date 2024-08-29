using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField] public int Value { get; private set; }

    public void Remove()
    {
        Destroy(gameObject);
    }
}