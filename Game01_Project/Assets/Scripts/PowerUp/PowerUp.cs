using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoreMountains.TopDownEngine
{
    public abstract class PowerUp : ScriptableObject
    {
        public Sprite _powerUpIcon;
        public string _powerUpName;
        public string _description;

        public abstract void Apply(Transform targetTransform);
    }
}
