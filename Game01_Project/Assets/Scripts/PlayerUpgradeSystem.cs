using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public static class PlayerUpgradeSystem
    {
        private static List<PowerUp> selectedPowerUpList = new List<PowerUp>();
        private static List<PowerUp> availablePowerUpList = new List<PowerUp>();

        public static List<PowerUp> GetSelectedPowerUpList()
        {
            return selectedPowerUpList;
        }

        public static List<PowerUp> GetAvailablePowerUpList()
        {
            return availablePowerUpList;
        }

        public static void AddSelectedPowerUpList(PowerUp newPowerUp)
        {
            selectedPowerUpList.Add(newPowerUp);
        }
    }
}