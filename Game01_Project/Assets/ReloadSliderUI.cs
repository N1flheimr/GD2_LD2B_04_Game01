using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    public class ReloadSliderUI : MonoBehaviour, MMEventListener<MMGameEvent>
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Weapon currentWeapon;

        private void Start()
        {
            slider = GetComponentInParent<Slider>();
            currentWeapon = GetComponentInParent<CharacterHandleWeapon>().InitialWeapon;
            SliderReset();
            SetSliderMaxValue(currentWeapon.ReloadTime);
            slider.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (slider.IsActive())
            {
                slider.value += Time.deltaTime;

                if (slider.value >= slider.maxValue)
                {
                    slider.gameObject.SetActive(false);
                    SliderReset();
                }
            }
        }

        private void SliderReset()
        {
            slider.value = 0;
        }

        private void SetSliderMaxValue(float maxValue)
        {
            slider.maxValue = maxValue;
        }

        public void OnMMEvent(MMGameEvent eventType)
        {
            if (eventType.EventName == "Reload")
            {
                currentWeapon = GetComponentInParent<CharacterHandleWeapon>().CurrentWeapon;
                SliderReset();
                SetSliderMaxValue(currentWeapon.ReloadTime);
                slider.gameObject.SetActive(true);
                Debug.Log("Reloading");
            }
        }

        protected void OnEnable()
        {
            this.MMEventStartListening<MMGameEvent>();
        }
    }
}