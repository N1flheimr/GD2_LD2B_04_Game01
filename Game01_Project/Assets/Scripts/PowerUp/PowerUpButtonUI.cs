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


        public void SetPowerUp(PowerUp upgrade)
        {
            _selectedPowerUp = upgrade;
            _playerTransform = GameObject.FindWithTag("Player").transform;
            UpdatePowerUpVisual();
            _button.onClick.AddListener(() =>
            {
                _selectedPowerUp.Apply(_playerTransform);
            });
        }

        public void UpdatePowerUpVisual()
        {
            _upgradeIcon.sprite = _selectedPowerUp.powerUpIcon;
            _upgradeName.text = _selectedPowerUp.powerUpName;
            _description.text = _selectedPowerUp.description;
        }
    }
}
