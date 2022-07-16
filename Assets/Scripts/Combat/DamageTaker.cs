using Codetox.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class DamageTaker : MonoBehaviour, IDamageTaker
    {
        public ValueReference<float> initialHealth;
        public ValueReference<float> currentHealth;

        public UnityEvent onHit;
        public UnityEvent onDie;

        private void OnEnable()
        {
            currentHealth.Value = initialHealth.Value;
        }

        public void TakeDamage(float amount)
        {
            currentHealth.Value -= amount;
            (currentHealth.Value > 0 ? onHit : onDie)?.Invoke();
        }
    }
}