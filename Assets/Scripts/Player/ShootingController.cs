using Codetox.Core;
using Codetox.GameEvents;
using Codetox.Misc;
using Codetox.Variables;
using UnityEngine;

namespace Player
{
    public class ShootingController : MonoBehaviour
    {
        [SerializeField] private Transform shootingSourceRight;
        [SerializeField] private Transform shootingSourceUp;
        [SerializeField] private ValueReference<Vector2> direction;
        [SerializeField] private ValueReference<float> bulletsPerSecond;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameEvent<GameObject> shootFlashEvent;

        private CoroutineBuilder _shootingCoroutine;

        private Range<float> _xRange = new(-0.75f, 0.75f);

        private void Awake()
        {
            _shootingCoroutine = gameObject.Coroutine(cancelOnDisable: true, destroyOnFinish: false).Invoke(Shoot).WaitForSeconds(1 / bulletsPerSecond.Value)
                .While(() => true);
        }

        public void StartShooting()
        {
            _shootingCoroutine.Run();
        }

        public void StopShooting()
        {
            _shootingCoroutine.Cancel();
        }

        public void Shoot()
        {
            ShootBullet(IsPointingUp() ? shootingSourceUp : shootingSourceRight);
        }

        private void ShootBullet(Transform source)
        {
            shootFlashEvent.Invoke(source.gameObject);
            Instantiate(bulletPrefab, source.position, source.rotation);
        }

        private bool IsPointingUp()
        {
            return direction.Value.y > 0.75f && _xRange.IsInRange(direction.Value.x);
        }
    }
}