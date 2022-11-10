using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MoreMountains.TopDownEngine
{
    public class PowerUpManagerUI : MonoBehaviour
    {
        private const int MAX_POWER_UP_NUMBER = 3;
        [SerializeField] private Transform powerUpButtonPrefab;
        [SerializeField] private Transform powerUpButtonContainerTransform;

        private List<PowerUpButtonUI> powerUpButtonUIList;

        [SerializeField] private Transform playerTransform;

        private void Awake()
        {
            powerUpButtonUIList = new List<PowerUpButtonUI>();
        }

        private void Start()
        {
            CreatePowerUpButtons();
            PowerUpManager.Instance.OnPowerUpSelectionStart += Test_OnPowerUpSelectionStart;
        }

        private void Test_OnPowerUpSelectionStart(object sender, EventArgs e)
        {
            CreatePowerUpButtons();
        }

        public void CreatePowerUpButtons()
        {
            foreach (Transform buttonTransform in powerUpButtonContainerTransform)
            {
                Destroy(buttonTransform.gameObject);
            }
            List<int> randomIndexList = new List<int>();

            randomIndexList.Clear();

            powerUpButtonUIList.Clear();

            while (powerUpButtonUIList.Count != MAX_POWER_UP_NUMBER)
            {
                PowerUpManager powerUpManager = PowerUpManager.Instance;
                int randomIndex = UnityEngine.Random.Range(0, powerUpManager.GetAvailablePowerUpList().Count);

                if (randomIndexList.Contains(randomIndex))
                {
                    Debug.Log("skipped" + randomIndex);
                    continue;
                }

                Transform powerUpButtonTransform = Instantiate(powerUpButtonPrefab, powerUpButtonContainerTransform);
                PowerUpButtonUI powerUpButtonUI = powerUpButtonTransform.GetComponent<PowerUpButtonUI>();
                powerUpButtonUIList.Add(powerUpButtonUI);

                powerUpButtonUI.SetPowerUp(powerUpManager.GetAvailablePowerUpList()[randomIndex]);
                randomIndexList.Add(randomIndex);

                UpdatePowerUpVisual();
            }
        }

        void UpdatePowerUpVisual()
        {
            foreach (PowerUpButtonUI powerUpButtonUI in powerUpButtonUIList)
            {
                powerUpButtonUI.UpdatePowerUpVisual();
            }
        }
    }
}