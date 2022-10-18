using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class WeaponDamageUpgrade : PowerUp
    {
        [SerializeField] private float amount = 15f;

        public override void Apply(Transform targetTransform)
        {
            throw new System.NotImplementedException();
        }
    }
}
