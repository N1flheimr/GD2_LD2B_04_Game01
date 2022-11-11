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
        [SerializeField] private Image[] allSpriteInSlider;
        private bool isSliderActive;

        private void Start()
        {
            slider = GetComponentInParent<Slider>();
            currentWeapon = GetComponentInParent<CharacterHandleWeapon>().InitialWeapon;
            SliderReset();
            SetSliderMaxValue(currentWeapon.ReloadTime);
            allSpriteInSlider = GetComponentsInChildren<Image>();
            foreach (Image image in allSpriteInSlider)
            {
                var tempColor = image.color;
                tempColor.a = 0f;
                image.color = tempColor;
            }
        }

        private void Update()
        {
            if (isSliderActive)
            {
                slider.value += Time.deltaTime;

                if (slider.value >= slider.maxValue)
                {
                    SliderReset();
                }
            }
        }

        private void SliderReset()
        {
            slider.value = 0;
            foreach (Image image in allSpriteInSlider)
            {
                var tempColor = image.color;
                tempColor.a = 0f;
                image.color = tempColor;
            }
            isSliderActive = false;
        }

        private void SetSliderMaxValue(float maxValue)
        {
            slider.maxValue = maxValue;
        }

        public void OnMMEvent(MMGameEvent eventType)
        {
            if (eventType.EventName == "ReloadEvent")
            {
                currentWeapon = GetComponentInParent<CharacterHandleWeapon>().CurrentWeapon;
                SliderReset();
                SetSliderMaxValue(currentWeapon.ReloadTime);
                foreach (Image image in allSpriteInSlider)
                {
                    var tempColor = image.color;
                    tempColor.a = 1f;
                    image.color = tempColor;
                }
                isSliderActive = true;
                Debug.Log("Reloading");
            }
        }

        protected void OnEnable()
        {
            this.MMEventStartListening<MMGameEvent>();
        }

        //protected void OnDisable()
        //{
        //    this.MMEventStopListening<MMGameEvent>();
        //}
    }
}