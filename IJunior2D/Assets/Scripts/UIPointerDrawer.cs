using UnityEngine;

public class UIPointerDrawer : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = _pointer.GetComponent<RectTransform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector2 anchoredPosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle
            ((RectTransform)_rectTransform.parent, mousePosition, null, out anchoredPosition);

        _rectTransform.anchoredPosition = anchoredPosition;
    }
}