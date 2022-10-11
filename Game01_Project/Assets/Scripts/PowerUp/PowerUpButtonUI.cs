using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MoreMountains.TopDownEngine
{
    public class PowerUpButtonUI : MonoBehaviour
    {
        [SerializeField] private PowerUp _selectedPowerUp;

        [SerializeField] private Image _upgradeIcon;
        [SerializeField] private TextMeshProUGUI _upgradeName;
        [SerializeField] private TextMeshProUGUI _description;

        [SerializeField] private Button _button;
        [SerializeField] private Transform _playerTransform;

        void Start()
        {
            SetPowerUp(_selectedPowerUp);
        }

        public void SetPowerUp(PowerUp upgrade)
        {
            _selectedPowerUp = upgrade;
            UpdatePowerUpVisual();
            _button.onClick.AddListener(() =>
            {
                _selectedPowerUp.Apply(_playerTransform);
            });
        }

        public void UpdatePowerUpVisual()
        {
            _upgradeIcon.sprite = _selectedPowerUp._powerUpIcon;
            _upgradeName.text = _selectedPowerUp._powerUpName;
            _description.text = _selectedPowerUp._description;
        }
    }
}
