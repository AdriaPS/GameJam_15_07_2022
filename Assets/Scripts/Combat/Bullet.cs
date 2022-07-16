using Codetox.Core;
using Codetox.Messaging;
using Codetox.Misc;
using Codetox.Variables;
using UnityEngine;

namespace Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private ValueReference<float> damage;
        [SerializeField] private ValueReference<float> speed;
        [SerializeField] private ValueReference<float> lifetime;
        [SerializeField] private Range<float> randomAngle;

        public void OnEnable()
        {
            rigidbody.velocity = transform.right.Rotate(Random.Range(randomAngle.min, randomAngle.max), transform.forward) * speed.Value;
            gameObject.Coroutine().WaitForSeconds(lifetime.Value).Invoke(() => Destroy(gameObject)).Run();
        }

        public void Hit(GameObject obj)
        {
            obj.Send<IDamageTaker>(damageTaker => damageTaker.TakeDamage(damage.Value));
            Destroy(gameObject);
        }
    }
}