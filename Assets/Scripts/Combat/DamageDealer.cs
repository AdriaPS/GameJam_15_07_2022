using Codetox.Messaging;
using Codetox.Variables;
using UnityEngine;

namespace Combat
{
    public class DamageDealer : MonoBehaviour, IDamageDealer
    {
        public ValueReference<float> damage;

        public void DealDamage(IDamageTaker taker)
        {
            taker.TakeDamage(damage.Value, transform);
        }

        public void DealDamage(GameObject obj)
        {
            obj.Send<IDamageTaker>(DealDamage);
        }
    }
}