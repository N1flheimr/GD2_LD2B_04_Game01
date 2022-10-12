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

        protected virtual void Awake()
        {
            
        }

        public abstract void Apply(Transform targetTransform);
    }
}
