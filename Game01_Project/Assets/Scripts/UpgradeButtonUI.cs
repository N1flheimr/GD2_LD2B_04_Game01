using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MoreMountains.TopDownEngine
{
    public class UpgradeButtonUI : MonoBehaviour
    {
        [SerializeField] private Upgrade _selectedUpgrade;

        [SerializeField] private Image _upgradeIcon;
        [SerializeField] private TextMeshProUGUI _upgradeName;
        [SerializeField] private TextMeshProUGUI _description;

        [SerializeField] private Button _button;
        [SerializeField] private Transform _playerTransform;

        void Start()
        {
            SetUpgrade(_selectedUpgrade);
        }

        public void SetUpgrade(Upgrade upgrade)
        {
            _selectedUpgrade = upgrade;
            UpdateUpgradeVisual();
            _button.onClick.AddListener(() =>
            {
                _selectedUpgrade.Apply(_playerTransform);
                Debug.Log("Health Upgraded. Max HP: " + _playerTransform.GetComponent<Health>().MaximumHealth);
                Debug.Log("Current HP: " + _playerTransform.GetComponent<Health>().CurrentHealth);
            });
        }

        public void UpdateUpgradeVisual()
        {
            _upgradeIcon.sprite = _selectedUpgrade._upgradeIcon;
            _upgradeName.text = _selectedUpgrade._upgradeName;
            _description.text = _selectedUpgrade._description;
        }
    }
}
