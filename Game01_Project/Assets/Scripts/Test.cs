using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class Test : MonoBehaviour
    {
        public PowerUpManagerUI powerUpManagerUI;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                powerUpManagerUI.CreatePowerUpButtons();
            }
        }
    }
}
