using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public abstract class WeaponChange : ScriptableObject
    {
        public Sprite _weaponIcon;
        public string _weaponName;
        public string _description;
    }
}