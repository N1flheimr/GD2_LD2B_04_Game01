using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MoreMountains.TopDownEngine
{
    public class Test : MonoBehaviour
    {
        public static Test Instance { get; private set; }

        public GameObject tankPrefab;
        public GameObject tankGameObject;
        public Transform enemySpawnPoint;

        public event EventHandler OnPowerUpSelectionStart;
        public PowerUpManagerUI powerUpManagerUI;
        public List<Projectile> projectileList;

        public GameObject powerUpUIGameObject;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
            }
        }
    }
}