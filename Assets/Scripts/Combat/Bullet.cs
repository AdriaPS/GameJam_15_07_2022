using Codetox.Core;
using Codetox.Messaging;
using Codetox.Misc;
using Codetox.Variables;
using UnityEngine;

namespace Combat
{
    public class Bullet : DamageDealer
    {
        [SerializeField] private ValueReference<float> speed;
        [SerializeField] private ValueReference<float> lifetime;
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private Range<float> randomAngle;

        public void OnEnable()
        {
            var angle = Random.Range(randomAngle.min, randomAngle.max);
            
            rigidbody.velocity = transform.right.Rotate(angle, transform.forward) * speed.Value;
            gameObject.Coroutine().WaitForSeconds(lifetime.Value).Invoke(() => Destroy(gameObject)).Run();
        }

        public void Hit(GameObject obj)
        {
            obj.Send<IDamageTaker>(damageTaker => damageTaker.TakeDamage(damage.Value, transform));
            Destroy(gameObject);
        }
    }
}