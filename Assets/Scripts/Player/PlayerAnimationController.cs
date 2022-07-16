using Codetox.Variables;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Variable<Vector2> direction;

        public bool IsGrounded { get; set; }
        public bool IsShooting { get; set; }

        private void Update()
        {
            string animation;

            if (IsGrounded)
            {
                if (direction.Value.x is > 0 or < 0)
                {
                    if (IsShooting)
                    {
                        if (direction.Value.y > 0.75f) animation = "Walk";
                        else animation = "Walk Shooting Forward";
                    }
                    else
                    {
                        animation = "Walk Shooting Forward";
                    }
                }
                else
                {
                    if (IsShooting)
                    {
                        if (direction.Value.y > 0.75f) animation = "Idle Shooting Upward";
                        else animation = "Idle Shooting Forward";
                    }
                    else
                    {
                        animation = "Idle Shooting Forward";
                    }
                }
            }
            else
            {
                if (rigidbody2D.velocity.y > 0f) animation = "Jump";
                else animation = "Fall";
            }

            animator.Play(animation);
        }
    }
}