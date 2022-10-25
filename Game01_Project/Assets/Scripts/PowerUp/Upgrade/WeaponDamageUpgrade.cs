using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Damage Upgrade")]
    public class WeaponDamageUpgrade : PowerUp
    {
        [SerializeField] private float amount = 15f;

        public override void Apply(Transform targetTransform)
        {
            CharacterHandleWeapon playerHandleWeapon = targetTransform.GetComponent<CharacterHandleWeapon>();

            ProjectileWeapon projectileWeapon = playerHandleWeapon.CurrentWeapon.GetComponent<ProjectileWeapon>();

            MMObjectPooler pooledGameObject = projectileWeapon.ObjectPooler;
            PowerUpSelectionCompleted();
        }
    }
}
