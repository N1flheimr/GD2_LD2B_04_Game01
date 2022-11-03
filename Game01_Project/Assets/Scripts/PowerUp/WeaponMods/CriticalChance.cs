using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Critical Chance")]
    public class CriticalChance : PowerUp
    {
        public static event EventHandler<WeaponModsAppliedEventArgs> OnCriticalChanceApplied;

        [SerializeField] private float amount = 5f;

        public override void Apply(Transform targetTransform)
        {
            OnCriticalChanceApplied?.Invoke(this, new WeaponModsAppliedEventArgs(amount));
            PowerUpSelectionCompleted();
        }
    }
}