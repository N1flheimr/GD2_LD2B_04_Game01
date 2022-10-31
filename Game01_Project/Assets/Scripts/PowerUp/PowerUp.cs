using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PowerUpType
{
    Upgrade,
    Weapon,
    Skill,
    WeaponMods
};
public class WeaponModsAppliedEventArgs : EventArgs
{
    public float multiplier;

    public WeaponModsAppliedEventArgs(float amount)
    {
        multiplier = amount / 100f;
    }
}

namespace MoreMountains.TopDownEngine
{
    public abstract class PowerUp : ScriptableObject
    {
        public static event EventHandler OnPowerUpSelectionComplete;

        public Sprite powerUpIcon;
        [TextArea]
        public string powerUpName;
        [TextArea]
        public string description;
        public PowerUpType powerUpType;

        public abstract void Apply(Transform targetTransform);

        protected void PowerUpSelectionCompleted()
        {
            OnPowerUpSelectionComplete?.Invoke(this, EventArgs.Empty);
        }
    }
}
