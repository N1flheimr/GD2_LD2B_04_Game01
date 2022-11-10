using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using System;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/SlowDownTime")]
    public class SlowDownTimeSkill : Skill
    {
        public static event EventHandler<WeaponModsAppliedEventArgs> OnSlowDownTimeSkillActive;
        public static event EventHandler OnSlowDownTimeSkillStop;

        [Tooltip("the time scale to switch to when the time control button gets pressed")]
        public float TimeScale = 0.35f;

        /// whether or not the timescale should get lerped
		[Tooltip("whether or not the timescale should get lerped")]
        public bool LerpTimeScale = true;
        /// the speed at which to lerp the timescale
        [Tooltip("the speed at which to lerp the timescale")]
        public float LerpSpeed;

        public float damageIncreaseAmount;
        public float critDamageIncreaseAmount;
        public float critChanceIncreaseAmount;

        public override void Activate(MMCooldown cooldown)
        {
            CharacterMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();

            MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, TimeScale, oneTimeDuration, LerpTimeScale, LerpSpeed, false);

            playerMovement.ApplyMovementMultiplier((playerMovement.MovementSpeedMultiplier / TimeScale), oneTimeDuration * TimeScale);

            isActive = true;
            cooldown.Start();

            OnSlowDownTimeSkillActive?.Invoke(
                this, new WeaponModsAppliedEventArgs(damageIncreaseAmount, critDamageIncreaseAmount, critChanceIncreaseAmount));
        }

        public override void Stop(MMCooldown cooldown)
        {
            cooldown.Stop();
            isActive = false;
            OnSlowDownTimeSkillStop?.Invoke(this, EventArgs.Empty);
            Debug.Log("Skill Stop");
        }
    }
}
