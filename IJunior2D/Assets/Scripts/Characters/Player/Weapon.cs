using UnityEngine;

namespace MainCharacter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == false)
                return;

            _playerAnimator.Play(PlayerAnimatorData.Params.Attack);
        }
    }
}