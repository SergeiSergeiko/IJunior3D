using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private PlayerDetecter _playerDetecter;
        [SerializeField] private int _followTime;

        private Coroutine _followTimer;

        public bool IsAttack { get; private set; }
        public Transform Target { get; private set; }

        private void OnEnable()
        {
            _playerDetecter.Spotted += OnPlayerSpottedHandler;
        }

        private void OnDisable()
        {
            _playerDetecter.Spotted -= OnPlayerSpottedHandler;
        }

        private IEnumerator FollowTimer()
        {
            float time = 0;

            while (time < _followTime)
            {
                time += Time.deltaTime;

                yield return null;
            }

            IsAttack = false;
        }

        private void StartFollowTimer()
        {
            if (_followTimer != null)
                StopCoroutine(FollowTimer());

            _followTimer = StartCoroutine(FollowTimer());
        }

        private void OnPlayerSpottedHandler(Transform target)
        {
            Target = target;
            IsAttack = true;
            StartFollowTimer();
        }
    }
}