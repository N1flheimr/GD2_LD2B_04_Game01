using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;


namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "UpgradeSystem/HealthUpgrade")]
    public class HealthUpgrade : Upgrade
    {
        [SerializeField] private float amount;
        public override void Apply(Transform targetTransform)
        {
            Debug.Log("Health Upgrade!");
        }
    }
}
