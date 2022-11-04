using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Weapon")]
    public class WeaponChange : PowerUp
    {
        [SerializeField] private Weapon newWeapon;
        [SerializeField] private float healAmount = 25f;

        public override void Apply(Transform targetTransform)
        {
            CharacterHandleWeapon characterHandleWeapon = targetTransform.GetComponent<CharacterHandleWeapon>();
            Health playerHealth = targetTransform.GetComponent<Health>();

            if (characterHandleWeapon.CurrentWeapon.name == newWeapon.name)
            {
                return;
            }
            characterHandleWeapon.ChangeWeapon(newWeapon, newWeapon.WeaponName, false);

            if (playerHealth.CurrentHealth < playerHealth.MaximumHealth)
            {
                playerHealth.SetHealth(playerHealth.CurrentHealth + healAmount);

                if (playerHealth.CurrentHealth > playerHealth.MaximumHealth)
                {
                    playerHealth.CurrentHealth = playerHealth.MaximumHealth;
                }
                playerHealth.UpdateHealthBar(true);
            }

            PowerUpSelectionCompleted();
            Debug.Log("Weapon Changed");
        }
    }
}