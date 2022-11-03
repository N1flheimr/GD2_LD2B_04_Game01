using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using System;

namespace MoreMountains.TopDownEngine
{

    [CreateAssetMenu(menuName = "PowerUpSystem/Damage Upgrade")]
    public class WeaponDamageUpgrade : PowerUp
    {
        public static event EventHandler<WeaponModsAppliedEventArgs> OnDamageUpgradeApplied;

        [SerializeField] private float amount = 15f;

        public override void Apply(Transform targetTransform)
        {
            OnDamageUpgradeApplied?.Invoke(this, new WeaponModsAppliedEventArgs(amount));
            PowerUpSelectionCompleted();
        }
    }
}
