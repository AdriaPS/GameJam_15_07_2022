using Codetox.Variables;
using UnityEngine;

namespace Player
{
    public class PlayerPositionController : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Variable<Vector2> currentPosition;
        [SerializeField] private Variable<Vector2> currentVelocity;

        private void Awake()
        {
            currentPosition.Value = rigidbody2D.position;
            currentVelocity.Value = rigidbody2D.velocity;
        }

        private void Update()
        {
            currentPosition.Value = rigidbody2D.position;
            currentVelocity.Value = rigidbody2D.velocity;
        }
    }
}