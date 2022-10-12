using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class Test : MonoBehaviour
    {
        public GameObject player;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                player.GetComponent<Health>().CurrentHealth -= 10;
                Debug.Log("HP: " + player.GetComponent<Health>().CurrentHealth);
            }
        }
    }
}
