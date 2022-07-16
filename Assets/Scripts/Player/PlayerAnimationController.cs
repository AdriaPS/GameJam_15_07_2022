using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private bool _isWalking, _isShooting;

        public void Walk(Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                animator.Play(_isShooting ? "Idle Shooting" : "Idle");
                _isWalking = false;
            }
            else
            {
                animator.Play(_isShooting ? "Walk Shooting" : "Walk");
                _isWalking = true;
            }
        }

        public void StartShooting()
        {
            animator.Play(_isWalking ? "Walk Shooting" : "Idle Shooting");
            _isShooting = true;
        }

        public void StopShooting()
        {
            animator.Play(_isWalking ? "Walk" : "Idle");
            _isShooting = false;
        }

        public void Hit()
        {
            animator.Play("Hit");
        }
    }
}