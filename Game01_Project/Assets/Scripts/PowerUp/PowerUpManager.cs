using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MoreMountains.TopDownEngine
{
    public class PowerUpManager : MonoBehaviour
    {
        public static PowerUpManager Instance { get; private set; }

        public event EventHandler OnPowerUpSelectionStart;

        [SerializeField] private List<PowerUp> selectedPowerUpList = new List<PowerUp>();
        [SerializeField] private List<PowerUp> availablePowerUpList = new List<PowerUp>();
        [SerializeField] private PowerUp[] allPowerUps;

        [SerializeField] private GameObject powerUpUIGameObject;

        private void Awake()
        {
            allPowerUps = Resources.LoadAll<PowerUp>("PowerUpList");
            Instance = this;
            foreach (PowerUp powerUp in allPowerUps)
            {
                availablePowerUpList.Add(powerUp);
            }
            powerUpUIGameObject.SetActive(false);
        }

        private void Start()
        {
            PowerUp.OnPowerUpSelectionComplete += PowerUp_OnPowerUpSelectionComplete;
        }

        public List<PowerUp> GetSelectedPowerUpList()
        {
            return selectedPowerUpList;
        }

        public void RemoveAvailablePowerUpList(PowerUp powerUp)
        {
            availablePowerUpList.Remove(powerUp);
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
        public void StartPowerUpSelection()
        {
            if (!powerUpUIGameObject.activeInHierarchy)
            {
                GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
                OnPowerUpSelectionStart?.Invoke(this, EventArgs.Empty);
                powerUpUIGameObject.SetActive(true);
            }
        }

        private void PowerUp_OnPowerUpSelectionComplete(object sender, EventArgs e)
        {
            GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
            powerUpUIGameObject.SetActive(false);
        }
    }
}