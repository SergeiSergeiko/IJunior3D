using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _collisionHandler;

    private int _coins;

    public int Coins
    {
        get => _coins;

        private set => _coins = Mathf.Clamp(value, 0, int.MaxValue);
    }

    private void OnEnable()
    {
        _collisionHandler.CoinPickUp += TakeCoin;
    }

    private void OnDisable()
    {
        _collisionHandler.CoinPickUp -= TakeCoin;
    }

    private void Start()
    {
        Coins = 0;
    }

    private void TakeCoin(int value)
    {
        Coins += value;
    }
}