using UnityEngine;

namespace MainCharacter
{
    public class Wallet : MonoBehaviour
    {
        private int _coins;

        public int Coins
        {
            get
            {
                return _coins;
            }

            private set
            {
                _coins = Mathf.Clamp(value, 0, int.MaxValue);
            }
        }

        private void Start()
        {
            Coins = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Coin coin))
            {
                Coins++;
                coin.Die();
            }
        }
    }
}