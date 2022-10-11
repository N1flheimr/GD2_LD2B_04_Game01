using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public static class PlayerUpgradeSystem
    {
        private static List<PowerUp> appliedPowerUpList = new List<PowerUp>();

        public static List<PowerUp> GetAppliedPowerUpList()
        {
            return appliedPowerUpList;
        }

        public static void AddAppliedUpgradesList(PowerUp newPowerUp)
        {
            appliedPowerUpList.Add(newPowerUp);
        }
    }
}