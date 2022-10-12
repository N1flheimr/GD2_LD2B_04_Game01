using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/ImmuneToKnockback")]
    public class ImmuneToKnockback : PowerUp
    {
        public override void Apply(Transform targetTransform)
        {
            Health health = targetTransform.GetComponent<Health>();
            health.ImmuneToKnockback = true;
            Debug.Log("ImmuneToKnockback = "+health.ImmuneToKnockback);
        }
    }
}