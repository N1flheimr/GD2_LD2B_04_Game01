using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Upgrade,
    Weapon,
    Skill
};

namespace MoreMountains.TopDownEngine
{
    public abstract class PowerUp : ScriptableObject
    {

        public Sprite powerUpIcon;
        [TextArea]
        public string powerUpName; 
        [TextArea]
        public string description;
        public PowerUpType powerUpType;

        public abstract void Apply(Transform targetTransform);

    }
}
