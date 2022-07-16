using Codetox.Core;
using Codetox.Variables;
using UnityEngine;

namespace AI.DiceEnemy
{
    public class DiceEnemyPositionController : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Variable<Vector2> playerPosition;
        [SerializeField] private ValueReference<float> distanceToPlayer;
        [SerializeField] private ValueReference<float> smoothTime;
        private Vector2 _current;

        private Vector2 _currentPosition;

        private void Update()
        {
            rigidbody2D.MovePosition(_currentPosition);
        }

        private void FixedUpdate()
        {
            var finalPosition = playerPosition.Value +
                                (Vector2) (rigidbody2D.transform.DirectionFrom(playerPosition.Value) *
                                           distanceToPlayer.Value);
            _currentPosition = Vector2.SmoothDamp(_currentPosition, finalPosition, ref _current, smoothTime.Value);
        }

        private void OnEnable()
        {
            _currentPosition = rigidbody2D.position;
        }
    }
}