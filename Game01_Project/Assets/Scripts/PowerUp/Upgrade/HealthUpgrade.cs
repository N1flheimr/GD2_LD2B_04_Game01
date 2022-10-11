using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;


namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/HealthUpgrade")]
    public class HealthUpgrade : PowerUp
    {
        [SerializeField] private float amount;

        public override void Apply(Transform targetTransform)
        {
            Health playerHealth = targetTransform.GetComponent<Health>();
            playerHealth.MaximumHealth += amount;
            playerHealth.UpdateHealthBar(true);
            Debug.Log("Max Health upgraded. Current Max HP: " + playerHealth.MaximumHealth);
            Debug.Log("Max Health upgraded. Current HP: " + playerHealth.CurrentHealth);
        }
    }
}
