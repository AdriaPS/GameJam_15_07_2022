using Codetox.Misc;
using Codetox.Variables;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Variable<Vector2> direction;

        private bool _isShooting;
        private Range<float> _xRange = new(-0.75f, 0.75f);

        public void OnJump()
        {
        }

        public void OnTouchGround()
        {
        }

        public void OnStartShooting()
        {
            _isShooting = true;
            PlayAnimation();
        }

        public void OnStopShooting()
        {
            _isShooting = false;
            PlayAnimation();
        }

        public void OnHit()
        {
            animator.Play("Hit");
        }

        public void OnMove()
        {
            PlayAnimation();
        }

        public void PlayAnimation()
        {
            if (direction.Value.x is > 0f or < 0f)
            {
                if (_isShooting)
                {
                    if (IsPointingUp()) animator.Play("Walk");
                    else animator.Play("Walk Shooting Forward");
                }
                else
                {
                    animator.Play("Walk");
                }
            }
            else
            {
                if (_isShooting)
                {
                    if (IsPointingUp()) animator.Play("Idle Shooting Upward");
                    else animator.Play("Idle Shooting Forward");
                }
                else
                {
                    animator.Play("Idle");
                }
            }
        }

        private bool IsPointingUp()
        {
            return direction.Value.y > 0.75f && _xRange.IsInRange(direction.Value.x);
        }
    }
}