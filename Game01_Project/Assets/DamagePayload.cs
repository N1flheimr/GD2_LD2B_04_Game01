using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    public class DamagePayload : MMPoolableObject
    {
        [SerializeField] private Projectile bullet;
        [SerializeField] private DamageOnTouch damageOnTouch;
        [SerializeField] private int originalMinDamage;
        [SerializeField] private int originalMaxDamage;

        public void ApplyModifier()
        {
            if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.DamageUpgrade))
            {
                if (bullet == null)
                {
                    bullet = this.GetComponent<Projectile>();
                    damageOnTouch = this.GetComponent<DamageOnTouch>();
                    originalMaxDamage = (int)damageOnTouch.MaxDamageCaused;
                    originalMinDamage = (int)damageOnTouch.MinDamageCaused;
                    Debug.Log("ModsSetup");
                }

                int minDamage =
                     (int)damageOnTouch.MinDamageCaused + Mathf.CeilToInt(damageOnTouch.MinDamageCaused * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.DamageUpgrade));
                int maxDamage =
                     (int)damageOnTouch.MaxDamageCaused + Mathf.CeilToInt(damageOnTouch.MaxDamageCaused * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.DamageUpgrade));
                bullet.SetDamage(minDamage, maxDamage);
                Debug.Log("ModifierApplied");
            }
        }

        public void ResetModifier()
        {
            bullet.SetDamage(originalMinDamage, originalMaxDamage);
        }
    }
}