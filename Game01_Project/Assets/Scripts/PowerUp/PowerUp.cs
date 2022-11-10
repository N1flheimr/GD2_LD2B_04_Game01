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
    public float damageIncreaseMult;
    public float critDamageIncreaseMult;
    public float critChanceIncreaseMult;


    public WeaponModsAppliedEventArgs(float amount)
    {
        multiplier = amount / 100f;
    }
    public WeaponModsAppliedEventArgs(float damageIncreaseAmount, float critDamageIncreaseAmount, float critChanceIncreaseAmount)
    {
        damageIncreaseMult = damageIncreaseAmount / 100f;
        critDamageIncreaseMult = critDamageIncreaseAmount / 100f;
        critChanceIncreaseMult = critChanceIncreaseAmount / 100f;
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
            PowerUpManager.Instance.AddSelectedPowerUpList(this);
            PowerUpManager.Instance.RemoveAvailablePowerUpList(this);
            OnPowerUpSelectionComplete?.Invoke(this, EventArgs.Empty);
        }
    }
}
