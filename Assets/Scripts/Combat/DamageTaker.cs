using System;
using Codetox.Core;
using Codetox.Messaging;
using Codetox.Variables;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class DamageTaker : MonoBehaviour, IDamageTaker
    {
        public new Rigidbody2D rigidbody2D;
        public ValueReference<float> initialHealth;
        public ValueReference<float> currentHealth;
        public ValueReference<float> recoilDistance;
        public ValueReference<float> recoilTime;
        public Ease recoilEase;

        public UnityEvent onHit;
        public UnityEvent onRecoilFinished;
        public UnityEvent onDie;

        private void Awake()
        {
            currentHealth.Value = initialHealth.Value;
            CanTakeDamage = true;
        }

        private void OnEnable()
        {
            currentHealth.Value = initialHealth.Value;
            CanTakeDamage = true;
        }

        public void TakeDamage(float amount, Transform source)
        {
            if (!CanTakeDamage) return;
            
            currentHealth.Value -= amount;
            
            if (currentHealth.Value <= 0)
            {
                onDie?.Invoke();
                return;
            }
            
            onHit?.Invoke();

            // rigidbody2D.isKinematic = true;
            // rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            rigidbody2D.
                DOMove(rigidbody2D.position + (Vector2)(source.DirectionTo(rigidbody2D.position) * recoilDistance.Value), recoilTime.Value).
                SetEase(recoilEase).
                OnComplete(() =>
                {
                    // rigidbody2D.isKinematic = false;
                    // rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                    onRecoilFinished?.Invoke();
                });
        }

        public bool CanTakeDamage { get; set; }
    }
}