using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.TopDownEngine
{
    public class PowerUpManagerUI : MonoBehaviour
    {

        [SerializeField] private Transform upgradeButtonPrefab;
        [SerializeField] private Transform upgradeButtonContainerTransform;

        private List<PowerUpButtonUI> UpgradeButtonUIList;

        private void Awake()
        {
            UpgradeButtonUIList = new List<PowerUpButtonUI>();
        }
    }
}