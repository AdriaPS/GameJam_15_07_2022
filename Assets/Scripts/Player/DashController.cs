using Codetox.Core;
using Codetox.Variables;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class DashController : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private ValueReference<float> distance;
        [SerializeField] private ValueReference<float> time;
        [SerializeField] private ValueReference<float> cooldown;
        [SerializeField] private Ease ease;

        public UnityEvent onFinished;

        private bool _isDashing, _isReady = true;

        private void Update()
        {
            if (!_isDashing && !_isReady) onFinished?.Invoke();
        }

        public void Dash()
        {
            if (!_isReady) return;

            var finalPosition = rigidbody.position.x + distance.Value * rigidbody.transform.right.x;

            _isReady = false;
            _isDashing = true;
            rigidbody.velocity = Vector2.zero;
            rigidbody.DOMoveX(finalPosition, time.Value).SetEase(ease).OnComplete(() =>
            {
                _isDashing = false;
                rigidbody.gameObject.Coroutine().WaitForSeconds(cooldown.Value).Invoke(() => _isReady = true).Run();
            });
        }
    }
}