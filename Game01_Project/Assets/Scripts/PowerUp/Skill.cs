using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    public abstract class Skill : ScriptableObject
    {
        public new string name;

        /// the cooldown for this ability
        [Tooltip("the cooldown for this ability")]
        public MMCooldown cooldown;

        public enum Modes { OneTime, Continuous }

        public Modes Mode = Modes.Continuous;

        [MMEnumCondition("Mode", (int)Modes.OneTime)]
        public float oneTimeDuration = 1f;


        public abstract void Activate(MMCooldown cooldown);
        public abstract void Stop(MMCooldown cooldown);
    }
}