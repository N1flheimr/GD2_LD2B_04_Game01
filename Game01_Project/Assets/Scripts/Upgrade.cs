using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoreMountains.TopDownEngine
{
    public abstract class Upgrade : ScriptableObject
    {
        public Sprite _upgradeIcon;
        public string _upgradeName;
        public string _description;

        public abstract void Apply(Transform targetTransform);
    }
}
