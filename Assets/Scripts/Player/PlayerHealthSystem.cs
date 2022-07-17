using System;
using Codetox.Variables;
using Combat;
using UnityEngine.Events;

namespace Player
{
    public class PlayerHealthSystem : DamageTaker
    {
        public ValueReference<float> maxHealingPoints;
        public ValueReference<float> healingPoints;
        public UnityEvent onHeal;

        public void AddHealingPoint()
        {
            if (Math.Abs(healingPoints.Value - maxHealingPoints.Value) < 0.001f) return;

            healingPoints.Value += 1f;
        }

        public void Heal()
        {
            if (Math.Abs(currentHealth.Value - initialHealth.Value) < 0.001f) return;
            if (healingPoints.Value == 0f) return;

            healingPoints.Value -= 1f;
            currentHealth.Value += 1f;

            if (currentHealth.Value > initialHealth.Value) currentHealth.Value = initialHealth.Value;

            onHeal?.Invoke();
        }
    }
}