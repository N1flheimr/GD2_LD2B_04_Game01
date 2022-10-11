using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Weapon")]
    public class WeaponChange : PowerUp
    {
        [SerializeField] private Weapon newWeapon;

        public override void Apply(Transform targetTransform)
        {
            CharacterHandleWeapon characterHandleWeapon = targetTransform.GetComponent<CharacterHandleWeapon>();

            if (characterHandleWeapon.CurrentWeapon.name == newWeapon.name)
            {
                return;
            }
            characterHandleWeapon.ChangeWeapon(newWeapon, newWeapon.WeaponName, false);

            Debug.Log("Weapon Changed");
        }
    }
}