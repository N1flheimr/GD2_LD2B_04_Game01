using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MoreMountains.TopDownEngine
{
    public class Test : MonoBehaviour
    {
        public static Test Instance { get; private set; }

        public event EventHandler OnPowerUpSelectionStart;
        public PowerUpManagerUI powerUpManagerUI;
        public List<Projectile> projectileList;

        public GameObject powerUpUIGameObject;

        private void Awake()
        {
            Instance = this;
            powerUpUIGameObject.SetActive(false);
        }
        private void Start()
        {
            PowerUp.OnPowerUpSelectionComplete += PowerUp_OnPowerUpSelectionComplete;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (!powerUpUIGameObject.activeInHierarchy)
                {
                    GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
                    powerUpUIGameObject.SetActive(true);
                    OnPowerUpSelectionStart?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void PowerUp_OnPowerUpSelectionComplete(object sender, EventArgs e)
        {
            GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
            powerUpUIGameObject.SetActive(false);
        }
    }
}
