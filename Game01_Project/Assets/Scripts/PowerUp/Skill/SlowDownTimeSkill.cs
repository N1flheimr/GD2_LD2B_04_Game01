using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/SlowDownTime")]
    public class SlowDownTimeSkill : Skill
    {

        [Tooltip("the time scale to switch to when the time control button gets pressed")]
        public float TimeScale = 0.5f;

        /// whether or not the timescale should get lerped
		[Tooltip("whether or not the timescale should get lerped")]
        public bool LerpTimeScale = true;
        /// the speed at which to lerp the timescale
        [Tooltip("the speed at which to lerp the timescale")]
        public float LerpSpeed = 5f;

        public override void Activate()
        {
            MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, TimeScale, oneTimeDuration, LerpTimeScale, LerpSpeed, false);
            cooldown.Start();
        }

        public override void Stop()
        {
            cooldown.Stop();
            Debug.Log("Skill Stop");
        }
    }
}
