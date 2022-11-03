using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/HealthUpgrade")]
    public class DamageOvertime : PowerUp
    {
        public override void Apply(Transform targetTransform)
        {

            PowerUpSelectionCompleted();
        }
    }
}
