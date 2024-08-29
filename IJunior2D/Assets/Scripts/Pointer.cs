using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(RectTransform))]
public class Pointer : MonoBehaviour
{
    public RectTransform GetRectTransform() => GetComponent<RectTransform>();
}