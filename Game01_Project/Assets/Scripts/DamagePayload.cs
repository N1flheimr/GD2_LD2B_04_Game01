using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

namespace MoreMountains.TopDownEngine
{
    public class DamagePayload : MonoBehaviour
    {
        [SerializeField] private Projectile bullet;
        [SerializeField] private DamageOnTouch damageOnTouch;

        private float minDamage;
        private float maxDamage;
        private float originalMinDamage;
        private float originalMaxDamage;

        [SerializeField] private float critDamageMult = 1.75f;
        [SerializeField] private float critChance = 4f;

        [SerializeField] private Skill currentPlayerSkill;

        private bool hasInitialized;

        public void ApplyModifier()
        {
            if (!hasInitialized)
            {
                Initialize();
            }

            ApplyDamageMods();

            ApplyCritical();

            bullet.SetDamage(Mathf.CeilToInt(minDamage), Mathf.CeilToInt(maxDamage));
            Debug.Log("ModifierApplied");
        }

        public void ResetModifier()
        {
            bullet.SetDamage(Mathf.CeilToInt(originalMinDamage), Mathf.CeilToInt(originalMaxDamage));
        }

        private void OnEnable()
        {
            ApplyModifier();
            Debug.Log("Bullet Damage: " + minDamage);
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

            if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.SlowDownCritChance))
            {
                critChance += WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.SlowDownCritChance) * 100f;
            }

            float critDamageMult = this.critDamageMult;
            if (randValue <= critChance)
            {
                if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.CriticalDamage))
                {
                    critDamageMult += WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.CriticalDamage);
                    Debug.Log("CritDamage: " + critDamageMult);
                }

                if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.SlowDownCritDamage))
                {
                    critDamageMult += WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.SlowDownCritDamage);
                }

                minDamage = Mathf.CeilToInt(minDamage * critDamageMult);
                maxDamage = Mathf.CeilToInt(maxDamage * critDamageMult);
                Debug.Log("CritMinDmg: " + minDamage);
            }
            Debug.Log("CritChance: " + critChance);
            Debug.Log("CritDamage: " + critDamageMult);
        }

        private void ApplyDamageMods()
        {
            minDamage = damageOnTouch.MinDamageCaused;
            maxDamage = damageOnTouch.MaxDamageCaused;

            if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.DamageUpgrade))
            {
                minDamage += (minDamage * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.DamageUpgrade));
                maxDamage += (maxDamage * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.DamageUpgrade));
            }

            if (WeaponModifier.Instance.GetWeaponMods(eWeaponModifierType.SlowDownDamage))
            {
                minDamage += minDamage * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.SlowDownDamage);
                maxDamage += maxDamage * WeaponModifier.Instance.GetMultAmount(eWeaponModifierType.SlowDownDamage);
            }
        }

        private void Initialize()
        {
            bullet = this.GetComponent<Projectile>();
            damageOnTouch = this.GetComponent<DamageOnTouch>();
            originalMaxDamage = damageOnTouch.MaxDamageCaused;
            originalMinDamage = damageOnTouch.MinDamageCaused;
            critChance = 4f;
            hasInitialized = true;
            Debug.Log("ModsSetup");
        }
    }
}