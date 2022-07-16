using Codetox.Variables;
using DG.Tweening;
using UnityEngine;

namespace AI.DiceEnemy
{
    public class DiceEnemyRotationController : MonoBehaviour
    {
        [SerializeField] private ValueReference<float> maxRotationSpeed;
        [SerializeField] private ValueReference<float> cycleTime;

        private Vector3 _rotationSpeed;

        private void Update()
        {
            transform.Rotate(_rotationSpeed * Time.deltaTime);
        }

        private void OnEnable()
        {
            DOVirtual.Float(-maxRotationSpeed.Value, maxRotationSpeed.Value, cycleTime.Value,
                value => _rotationSpeed.x = value).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

            DOVirtual.Float(maxRotationSpeed.Value, -maxRotationSpeed.Value, cycleTime.Value / 2,
                value => _rotationSpeed.y = value).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

            DOVirtual.Float(-maxRotationSpeed.Value, maxRotationSpeed.Value, cycleTime.Value / 3,
                value => _rotationSpeed.y = value).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }
    }
}