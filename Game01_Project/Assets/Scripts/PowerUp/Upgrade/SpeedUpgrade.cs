using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Speed Upgrade")]
    public class SpeedUpgrade : PowerUp
    {
        [SerializeField] private float amount;
        public override void Apply(Transform targetTransform)
        {
            CharacterMovement characterMovement = targetTransform.GetComponent<CharacterMovement>();
            float speedIncreaseAmount = characterMovement.MovementSpeed * (amount / 100);
            characterMovement.MovementSpeed += speedIncreaseAmount;
            PowerUpSelectionCompleted();
            Debug.Log("walk speed: " + characterMovement.MovementSpeed);
        }
    }
}