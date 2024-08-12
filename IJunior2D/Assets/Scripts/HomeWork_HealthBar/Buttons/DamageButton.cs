using UnityEngine;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private Button _button;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClikHandle);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClikHandle);
    }

    private void OnClikHandle()
    {
        _playerCollisionHandler.TakeDamage(_damage);
    }
}