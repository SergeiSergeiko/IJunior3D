using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform[] _hearts;

    private void Awake()
    {
        _hearts = new Transform[transform.childCount];

        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i] = transform.GetChild(i);
    }

    public void Refresh(int health)
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < health)
                _hearts[i].gameObject.SetActive(true);
            else
                _hearts[i].gameObject.SetActive(false);
        }
    }
}