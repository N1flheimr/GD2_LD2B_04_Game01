using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Critical Damage")]
    public class CritDamageIncrease : PowerUp
    {
        public static event EventHandler<WeaponModsAppliedEventArgs> OnCriticalDamageApplied;

        [SerializeField] private float amount = 15f;

        public override void Apply(Transform targetTransform)
        {
            OnCriticalDamageApplied?.Invoke(this, new WeaponModsAppliedEventArgs(amount));
            PowerUpSelectionCompleted();
        }
    }
}