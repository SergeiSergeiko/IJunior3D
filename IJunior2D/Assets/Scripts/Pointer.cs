using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Pointer : MonoBehaviour
{
    private Image _sprite;

    private void Start()
    {
        _sprite = GetComponent<Image>();
    }
}