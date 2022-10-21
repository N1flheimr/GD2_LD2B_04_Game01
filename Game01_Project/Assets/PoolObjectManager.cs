using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public class PoolObjectManager : MonoBehaviour
    {
        public static PoolObjectManager Instance { get; private set; }
        [SerializeField] private List<DamageOnTouch> damageOnTouchList = new List<DamageOnTouch>();

        private void Start()
        {
            //DamageOnTouch[] damageOnTouchArray = FindObjectsOfType<DamageOnTouch>();
            //foreach (DamageOnTouch damageOnTouch in damageOnTouchArray)
            //{
            //    damageOnTouchList.Add(damageOnTouch);
            //}
        }

        public void AddDamageOnTouchList()
        {
            DamageOnTouch[] damageOnTouchArray = FindObjectsOfType<DamageOnTouch>();
            foreach (DamageOnTouch damageOnTouch in damageOnTouchArray)
            {
                damageOnTouchList.Add(damageOnTouch);
            }
        }

        public void AddDamage()
        {
            DamageOnTouch damageOnTouch = GetComponent<DamageOnTouch>();
            damageOnTouch.MaxDamageCaused += 10;
        }
    }
}
