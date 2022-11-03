using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    public class DamagePayload : MonoBehaviour
    {
        [SerializeField] private Projectile bullet;
        [SerializeField] private DamageOnTouch damageOnTouch;
        private int minDamage;
        private int maxDamage;
        [SerializeField] private int originalMinDamage;
        [SerializeField] private int originalMaxDamage;
        [SerializeField] private float critDamageMult = 1.5f;
        [SerializeField] private float critChance = 4f;
        private bool hasInitialized;

        public void ApplyModifier()
        {
            if (!hasInitialized)
            {
                Initialize();
            }

            minDamage =
                 (int)damageOnTouch.MinDamageCaused + Mathf.CeilToInt(damageOnTouch.MinDamageCaused * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.DamageUpgrade));
            maxDamage =
                 (int)damageOnTouch.MaxDamageCaused + Mathf.CeilToInt(damageOnTouch.MaxDamageCaused * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.DamageUpgrade));

            ApplyCritical();

            bullet.SetDamage(minDamage, maxDamage);
            Debug.Log("ModifierApplied");
        }

        public void ResetModifier()
        {
            bullet.SetDamage(originalMinDamage, originalMaxDamage);
        }

        private void OnEnable()
        {
            ApplyModifier();
        }

        private void OnDisable()
        {
            ResetModifier();
        }

        private void ApplyCritical()
        {
            int randValue = Random.Range(1, 100);

            float critChance = this.critChance;
            if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.CriticalChance))
            {
                critChance += WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.CriticalChance) * 100f;
                Debug.Log("CritChance: " + critChance);
            }

            float critDamageMult = this.critDamageMult;
            if (randValue <= critChance)
            {
                if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.CriticalDamage))
                {
                    critDamageMult += WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.CriticalDamage);
                    Debug.Log("CritDamage: " + critDamageMult);
                }
                minDamage = Mathf.CeilToInt(minDamage * critDamageMult);
                maxDamage = Mathf.CeilToInt(maxDamage * critDamageMult);
                Debug.Log("CritMinDmg: " + minDamage);
            }
        }

        private void Initialize()
        {
            bullet = this.GetComponent<Projectile>();
            damageOnTouch = this.GetComponent<DamageOnTouch>();
            originalMaxDamage = (int)damageOnTouch.MaxDamageCaused;
            originalMinDamage = (int)damageOnTouch.MinDamageCaused;
            critChance = 4f;
            hasInitialized = true;
            Debug.Log("ModsSetup");
        }
    }
}