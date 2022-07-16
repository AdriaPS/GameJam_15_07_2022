using System.Collections;
using Codetox.Core;
using Codetox.Misc;
using UnityEngine;

namespace AI.DiceEnemy
{
    public class DiceEnemyBulletController : MonoBehaviour
    {
        [SerializeField] private Transform enemyTransform;
        [SerializeField] private Range<float> timeRange;
        [SerializeField] private Range<int> bulletRange;
        [SerializeField] private GameObject bulletPrefab;

        private void OnEnable()
        {
            StartCoroutine(FireBullets());
        }

        private IEnumerator FireBullets()
        {
            while (true)
            {
                var time = Random.Range(timeRange.min, timeRange.max);

                yield return new WaitForSeconds(time);

                var bulletAmount = Random.Range(bulletRange.min, bulletRange.max);
                var deltaAngles = 360f / bulletAmount;
                var angle = 0f;

                for (var i = 0; i < bulletAmount; i++)
                {
                    var direction = enemyTransform.up.Rotate(angle, enemyTransform.forward);
                    var up = Quaternion.Euler(0, 0, 90) * direction;
                    var bullet = Instantiate(bulletPrefab, enemyTransform.position + direction, Quaternion.LookRotation(Vector3.forward, up), enemyTransform);

                    angle += deltaAngles;
                }
            }
        }
    }
}