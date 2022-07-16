using UnityEngine;

namespace Combat
{
    public interface IDamageDealer
    {
        void DealDamage(IDamageTaker taker);
        void DealDamage(GameObject obj);
    }
}