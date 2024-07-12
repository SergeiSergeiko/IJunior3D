using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private int _treatHealth;

    public int Value { get; private set; }

    private void Start()
    {
        Value = _treatHealth;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}