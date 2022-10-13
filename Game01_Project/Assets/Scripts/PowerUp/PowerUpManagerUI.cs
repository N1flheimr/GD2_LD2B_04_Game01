using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.TopDownEngine
{
    public class PowerUpManagerUI : MonoBehaviour
    {
        private const int MAX_POWER_UP_NUMBER = 3;
        [SerializeField] private Transform powerUpButtonPrefab;
        [SerializeField] private Transform powerUpButtonContainerTransform;

        private PowerUp selectedPowerUp;

        private List<PowerUpButtonUI> powerUpButtonUIList;

        [SerializeField] private Transform playerTransform;

        private void Awake()
        {
            powerUpButtonUIList = new List<PowerUpButtonUI>();
        }

        private void Start()
        {
            CreatePowerUpButtons();
        }

        public void CreatePowerUpButtons()
        {
            foreach (Transform buttonTransform in powerUpButtonContainerTransform)
            {
                Destroy(buttonTransform.gameObject);
            }

            powerUpButtonUIList.Clear();

            for (int i = 0; i < MAX_POWER_UP_NUMBER; i++)
            {
                PowerUpManager powerUpManager = PowerUpManager.Instance;
                int randomIndex = Random.Range(0, powerUpManager.GetAvailablePowerUpList().Count);

                Transform powerUpButtonTransform = Instantiate(powerUpButtonPrefab, powerUpButtonContainerTransform);
                PowerUpButtonUI powerUpButtonUI = powerUpButtonTransform.GetComponent<PowerUpButtonUI>();
                powerUpButtonUIList.Add(powerUpButtonUI);

                powerUpButtonUI.SetPowerUp(powerUpManager.GetAvailablePowerUpList()[randomIndex]);
                UpdatePowerUpVisual();
            }
        }

         void UpdatePowerUpVisual()
        {
            foreach(PowerUpButtonUI powerUpButtonUI in powerUpButtonUIList)
            {
                powerUpButtonUI.UpdatePowerUpVisual();
            }
        }
    }
}