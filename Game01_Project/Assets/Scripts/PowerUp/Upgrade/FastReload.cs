using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Fast Reload Upgrade")]
    public class FastReload : PowerUp
    {
        public static event EventHandler<WeaponModsAppliedEventArgs> OnFastReloadApplied;

        public float amount;
        public override void Apply(Transform targetTransform)
        {
            CharacterHandleWeapon characterHandleWeapon = targetTransform.GetComponent<CharacterHandleWeapon>();
            Weapon currentWeapon = characterHandleWeapon.CurrentWeapon.GetComponent<Weapon>();

            float amountMult = amount / 100f;

            currentWeapon.ReloadTime -= currentWeapon.ReloadTime * amountMult;
            OnFastReloadApplied?.Invoke(this, new WeaponModsAppliedEventArgs(amount));
            Debug.Log("Speed: " + currentWeapon.ReloadTime);
        }
    }
}