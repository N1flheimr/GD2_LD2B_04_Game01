using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.TopDownEngine
{
    public class UpgradeManagerUI : MonoBehaviour
    {

        [SerializeField] private Transform upgradeButtonPrefab;
        [SerializeField] private Transform upgradeButtonContainerTransform;

        private List<UpgradeButtonUI> UpgradeButtonUIList;

        private void Awake()
        {
            UpgradeButtonUIList = new List<UpgradeButtonUI>();
        }
    }
}