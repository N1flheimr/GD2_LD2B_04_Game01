using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class Test : MonoBehaviour
    {
        public PowerUpManagerUI powerUpManagerUI;
        public List<Projectile> projectileList;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                powerUpManagerUI.CreatePowerUpButtons();
                Projectile[] projectileArray = FindObjectsOfType<Projectile>();
            }
        }
    }
}
