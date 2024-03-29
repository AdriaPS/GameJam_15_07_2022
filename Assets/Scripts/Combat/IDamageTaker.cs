﻿using UnityEngine;

namespace Combat
{
    public interface IDamageTaker
    {
        void TakeDamage(float amount, Transform source);
        bool CanTakeDamage { get; set; }
    }
}