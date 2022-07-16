using System.Collections;
using Codetox.Messaging;
using Codetox.Variables;
using Combat;
using DG.Tweening;
using UnityEngine;

namespace AI.DiceEnemy
{
    public class DiceEnemyBullet : DamageDealer
    {
        [SerializeField] private ValueReference<float> acceleration;
        [SerializeField] private Variable<Vector2> playerPosition;
        [SerializeField] private new Rigidbody2D rigidbody;

        private float _speed;

        private void OnEnable()
        {
            _speed = 0f;
            rigidbody.DOMove(rigidbody.position + (Vector2) transform.right * 1.5f, 0.5f)
                .OnComplete(() =>
                {
                    transform.parent = null;
                    StartCoroutine(AccelerateTowardsPlayer());
                });
        }

        private IEnumerator AccelerateTowardsPlayer()
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 5f));
            while (true)
            {
                _speed += acceleration.Value * Time.deltaTime;
                rigidbody.MovePosition(Vector2.MoveTowards(rigidbody.position, playerPosition.Value,
                    _speed * Time.deltaTime));

                yield return new WaitForEndOfFrame();
            }
        }

        public void Hit(GameObject obj)
        {
            obj.Send<IDamageTaker>(damageTaker => damageTaker.TakeDamage(damage.Value, transform));
            Destroy(gameObject);
        }
    }
}