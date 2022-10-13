using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class PlayerUpgradeSystem : MonoBehaviour
    {
        public static PlayerUpgradeSystem Instance { get; private set; }

        private List<PowerUp> selectedPowerUpList = new List<PowerUp>();
        private List<PowerUp> availablePowerUpList = new List<PowerUp>();

        private void Awake()
        {
            Instance = this;
        }

        public List<PowerUp> GetSelectedPowerUpList()
        {
            return selectedPowerUpList;
        }

        public List<PowerUp> GetAvailablePowerUpList()
        {
            return availablePowerUpList;
        }

        public void AddSelectedPowerUpList(PowerUp newPowerUp)
        {
            selectedPowerUpList.Add(newPowerUp);
        }

        public void AddavailablePowerUpList(PowerUp powerUp)
        {
            availablePowerUpList.Add(powerUp);
        }
    }
}