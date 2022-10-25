using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class Test : MonoBehaviour
    {
        public PowerUpManagerUI powerUpManagerUI;
        public List<Projectile> projectileList;

        public GameObject powerUpUIGameObject;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (!powerUpManagerUI.isActiveAndEnabled)
                {
                    GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
                    powerUpUIGameObject.SetActive(true);
                }
                else
                {
                    GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
                    powerUpUIGameObject.SetActive(false);
                }
            }
        }
    }
}
