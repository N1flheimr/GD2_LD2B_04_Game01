using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Magazine Increase")]
    public class MagazineIncrease : PowerUp
    {
        public static event EventHandler<WeaponModsAppliedEventArgs> OnMagazineIncreaseApplied;

        public float amount;
        public override void Apply(Transform targetTransform)
        {
            CharacterHandleWeapon characterHandleWeapon = targetTransform.GetComponent<CharacterHandleWeapon>();
            Weapon currentWeapon = characterHandleWeapon.CurrentWeapon.GetComponent<Weapon>();

            float amountMult = amount / 100f;
            if (currentWeapon.WeaponName != "O'Five")
            {
                currentWeapon.MagazineSize += Mathf.RoundToInt(currentWeapon.MagazineSize * amountMult);
            }
            else
            {
                currentWeapon.MagazineSize += Mathf.RoundToInt(currentWeapon.MagazineSize * amountMult * 2f);
            }


            OnMagazineIncreaseApplied?.Invoke(this, new WeaponModsAppliedEventArgs(amount));
            PowerUpSelectionCompleted();
            Debug.Log("MagSize: " + currentWeapon.MagazineSize);
        }
    }
}
