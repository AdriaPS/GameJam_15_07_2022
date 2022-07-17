using UnityEngine;

namespace AI
{
    public class MeleeShield : MonoBehaviour
    {
        public new Rigidbody2D rigidbody2D;
        public float speed;

        void FixedUpdate()
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.transform.right.x * speed, rigidbody2D.velocity.y);
        }

        public void RotateEnemy()
        {
            transform.Rotate(0, 180, 0);
        }
    }
}

