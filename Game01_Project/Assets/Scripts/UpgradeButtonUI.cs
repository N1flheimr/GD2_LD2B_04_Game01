using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MoreMountains.TopDownEngine
{
    public class UpgradeButtonUI : MonoBehaviour
    {
        [SerializeField] private Upgrade _clickedUpgrade;

        [SerializeField] private Image _upgradeIcon;
        [SerializeField] private TextMeshProUGUI _upgradeName;
        [SerializeField] private TextMeshProUGUI _description;


        [SerializeField] private Button upgradeButton;
        [SerializeField] private Transform playerTransform;

        void Start()
        {
            upgradeButton.onClick.AddListener(() =>
            {
                _clickedUpgrade.Apply(playerTransform);
            });
            UpdateUpgradeVisual();
        }

        public void UpdateUpgradeVisual()
        {
            _upgradeIcon.sprite = _clickedUpgrade._upgradeIcon;
            _upgradeName.text = _clickedUpgrade._upgradeName;
            _description.text = _clickedUpgrade._description;
        }
    }
}
