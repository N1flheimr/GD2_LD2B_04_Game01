using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

namespace MoreMountains.TopDownEngine
{
    [AddComponentMenu("TopDown Engine/Character/Abilities/CharacterSkill")]
    public class CharacterSkill : CharacterAbility
    {
        public Skill currentSkill;

        /// the cooldown for this ability
        [Tooltip("the cooldown for this ability")]
        public MMCooldown cooldown;


        /// <summary>
        /// Here you should initialize our parameters
        /// </summary>
        protected override void Initialization()
        {
            base.Initialization();
            cooldown.Initialization();
        }

        /// <summary>
        /// Every frame, we check if we're crouched and if we still should be
        /// </summary>
        public override void ProcessAbility()
        {
            base.ProcessAbility();
            cooldown.Update();
        }

        protected virtual void ActivateSkill()
        {
            cooldown = currentSkill.cooldown;

            if (cooldown.Ready())
            {
                PlayAbilityStartFeedbacks();

                currentSkill.Activate(cooldown);
                cooldown.Start();
            }
        }

        protected virtual void StopSkill()
        {
            StopStartFeedbacks();
            PlayAbilityStopFeedbacks();
            currentSkill.Stop(cooldown);
        }

        /// <summary>
        /// Called at the start of the ability's cycle, this is where you'll check for input
        /// </summary>
        protected override void HandleInput()
        {
            base.HandleInput();
            if (!AbilityAuthorized)
            {
                return;
            }

            if (_inputManager.ActivateSkillButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
            {
                ActivateSkill();
            }
            if (_inputManager.ActivateSkillButton.State.CurrentState == MMInput.ButtonStates.ButtonUp)
            {
                StopSkill();
            }
        }

        public void ChangeSkill(Skill skill)
        {
            currentSkill = skill;
            cooldown = currentSkill.cooldown;
            cooldown.CurrentDurationLeft = currentSkill.cooldown.RefillDuration;
        }
    }
}