using Codetox.Misc;
using Codetox.Pooling;
using Codetox.Variables;
using UnityEngine;

namespace Player
{
    public class ShootingController: MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private ValueReference<Vector2> direction;
        [SerializeField] private ValueReference<float> bulletsPerSecond;
        [SerializeField] private GameObjectPool bulletPool;

        private Range<float> xRange = new(-0.75f, 0.75f);

        public void Shoot()
        {
            if (IsPointingUp())
            {
                ShootBullet(playerTransform.up);
            }
            else
            {
                ShootBullet(playerTransform.forward);
            }
        }
        
        private void ShootBullet(Vector3 dir)
        {
            var bullet = bulletPool.Get();
        }

        private bool IsPointingUp()
        {
            return direction.Value.y > 0f && xRange.IsInRange(direction.Value.x);
        }
    }
}