using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using System;

namespace MoreMountains.TopDownEngine
{
    public enum eWeaponModifierType
    {
        DamageUpgrade,
        FastReload,
        MagazineIncrease,
        CriticalChance,
        CriticalDamage,
        SlowDownDamage,
        SlowDownCritDamage,
        SlowDownCritChance,
        lastWeaponMod
    }
    public class WeaponModifier : MonoBehaviour
    {
        public static WeaponModifier Instance;

        [SerializeField] private bool[] weaponModsArray;

        [SerializeField] private float[] multAmountArray;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            weaponModsArray = new bool[(int)eWeaponModifierType.lastWeaponMod];
            multAmountArray = new float[(int)eWeaponModifierType.lastWeaponMod];

            CharacterHandleWeapon.OnPlayerWeaponChanged += CharacterHandleWeapon_OnWeaponChanged;
            FastReload.OnFastReloadApplied += FastReload_OnFastReloadApplied;
            MagazineIncrease.OnMagazineIncreaseApplied += MagazineIncrease_OnMagazineIncreaseApplied;
            WeaponDamageUpgrade.OnDamageUpgradeApplied += WeaponDamageUpgrade_OnDamageUpgradeApplied;
            CriticalChance.OnCriticalChanceApplied += CriticalChance_OnCriticalChanceApplied;
            CritDamageIncrease.OnCriticalDamageApplied += CritDamageIncrease_OnCriticalDamageApplied;
            SlowDownTimeSkill.OnSlowDownTimeSkillActive += SlowDownTimeSkill_OnSlowDownTimeSkillActive;
            SlowDownTimeSkill.OnSlowDownTimeSkillStop += SlowDownTimeSkill_OnSlowDownTimeSkillStop;
        }

        private void CharacterHandleWeapon_OnWeaponChanged()
        {
            ApplyModsOnweaponChange();
            Debug.Log("WeaponMods WeaponChanged");
        }

        public void ApplyModsOnweaponChange()
        {
            if (weaponModsArray[(int)eWeaponModifierType.FastReload])
            {
                CharacterHandleWeapon characterHandleWeapon = gameObject.GetComponent<CharacterHandleWeapon>();
                characterHandleWeapon.CurrentWeapon.ReloadTime -=
                    characterHandleWeapon.CurrentWeapon.ReloadTime * multAmountArray[(int)eWeaponModifierType.FastReload];
                Debug.Log("OnFastReloadAppliedAndWeaponChanged");
            }

            if (weaponModsArray[(int)eWeaponModifierType.MagazineIncrease])
            {
                CharacterHandleWeapon characterHandleWeapon = gameObject.GetComponent<CharacterHandleWeapon>();
                Weapon currentWeapon = characterHandleWeapon.CurrentWeapon.GetComponent<Weapon>();

                if (currentWeapon.WeaponName != "O'Five")
                {
                    currentWeapon.MagazineSize +=
                        Mathf.RoundToInt(currentWeapon.MagazineSize * multAmountArray[(int)eWeaponModifierType.MagazineIncrease]);
                }
                else
                {
                    currentWeapon.MagazineSize +=
                        Mathf.RoundToInt(currentWeapon.MagazineSize * multAmountArray[(int)eWeaponModifierType.MagazineIncrease] * 2);
                }
            }
        }

        private void FastReload_OnFastReloadApplied(object sender, WeaponModsAppliedEventArgs args)
        {
            multAmountArray[(int)eWeaponModifierType.FastReload] += args.multiplier;
            weaponModsArray[(int)eWeaponModifierType.FastReload] = true;
            Debug.Log("Fastreload Events went through amount: " + multAmountArray[(int)eWeaponModifierType.FastReload]);
        }
        private void MagazineIncrease_OnMagazineIncreaseApplied(object sender, WeaponModsAppliedEventArgs args)
        {
            multAmountArray[(int)eWeaponModifierType.MagazineIncrease] += args.multiplier;
            weaponModsArray[(int)eWeaponModifierType.MagazineIncrease] = true;
            Debug.Log("magazine Increase Events went through amount: " + multAmountArray[(int)eWeaponModifierType.MagazineIncrease]);
        }

        private void WeaponDamageUpgrade_OnDamageUpgradeApplied(object sender, WeaponModsAppliedEventArgs args)
        {
            multAmountArray[(int)eWeaponModifierType.DamageUpgrade] += args.multiplier;
            weaponModsArray[(int)eWeaponModifierType.DamageUpgrade] = true;

            Debug.Log(multAmountArray[(int)eWeaponModifierType.DamageUpgrade]);
        }

        private void CriticalChance_OnCriticalChanceApplied(object sender, WeaponModsAppliedEventArgs args)
        {
            multAmountArray[(int)eWeaponModifierType.CriticalChance] += args.multiplier;
            weaponModsArray[(int)eWeaponModifierType.CriticalChance] = true;
        }
        private void CritDamageIncrease_OnCriticalDamageApplied(object sender, WeaponModsAppliedEventArgs args)
        {
            multAmountArray[(int)eWeaponModifierType.CriticalDamage] += args.multiplier;
            weaponModsArray[(int)eWeaponModifierType.CriticalDamage] = true;
        }

        private void SlowDownTimeSkill_OnSlowDownTimeSkillActive(object sender, WeaponModsAppliedEventArgs args)
        {
            weaponModsArray[(int)eWeaponModifierType.SlowDownDamage] = true;
            weaponModsArray[(int)eWeaponModifierType.SlowDownCritChance] = true;
            weaponModsArray[(int)eWeaponModifierType.SlowDownCritDamage] = true;
            multAmountArray[(int)eWeaponModifierType.SlowDownDamage] = args.damageIncreaseMult;
            multAmountArray[(int)eWeaponModifierType.SlowDownCritChance] = args.critChanceIncreaseMult;
            multAmountArray[(int)eWeaponModifierType.SlowDownCritDamage] = args.critDamageIncreaseMult;
        }

        private void SlowDownTimeSkill_OnSlowDownTimeSkillStop(object sender, EventArgs e)
        {
            weaponModsArray[(int)eWeaponModifierType.SlowDownDamage] = false;
            weaponModsArray[(int)eWeaponModifierType.SlowDownCritChance] = false;
            weaponModsArray[(int)eWeaponModifierType.SlowDownCritDamage] = false;
        }

        public bool GetWeaponMods(eWeaponModifierType weaponModifierType)
        {
            return weaponModsArray[(int)weaponModifierType];
        }

        public float GetMultAmount(eWeaponModifierType weaponModifierType)
        {
            return multAmountArray[(int)weaponModifierType];
        }
        private void OnDestroy()
        {
            CharacterHandleWeapon.OnPlayerWeaponChanged -= CharacterHandleWeapon_OnWeaponChanged;
        }
    }
}