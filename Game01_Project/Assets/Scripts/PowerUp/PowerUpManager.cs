using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class PowerUpManager : MonoBehaviour
    {
        public static PowerUpManager Instance { get; private set; }

        [SerializeField] private List<PowerUp> selectedPowerUpList = new List<PowerUp>();
        [SerializeField] private List<PowerUp> availablePowerUpList = new List<PowerUp>();
        [SerializeField] private PowerUp[] allPowerUps;

        private void Awake()
        {
            allPowerUps = Resources.LoadAll<PowerUp>("PowerUpList");
            Instance = this;
            foreach (PowerUp powerUp in allPowerUps)
            {
                availablePowerUpList.Add(powerUp);
            }
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