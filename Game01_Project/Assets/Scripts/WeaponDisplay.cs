using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.TopDownEngine;
using System;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private Image weaponIcon;
    [SerializeField] private CharacterHandleWeapon characterHandleWeapon;

    private void Start()
    {
        characterHandleWeapon = LevelManager.Instance.SceneCharacters[0].GetComponent<CharacterHandleWeapon>();
        weaponName.text = "Skippy";
        PowerUp.OnPowerUpSelectionComplete += PowerUp_OnPowerUpSelectionComplete;
    }

    private void PowerUp_OnPowerUpSelectionComplete(object sender, EventArgs e)
    {
        if (weaponName.text != characterHandleWeapon.CurrentWeapon.WeaponName)
        {
            weaponName.text = characterHandleWeapon.CurrentWeapon.WeaponName;
            weaponIcon.sprite = characterHandleWeapon.CurrentWeapon.weaponSprite;
        }
    }
}
