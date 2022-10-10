using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    public static class PlayerUpgradeSystem
    {
        private static List<Upgrade> appliedUpgradesList = new List<Upgrade>();

        public static List<Upgrade> GetAppliedUpgradesList()
        {
            return appliedUpgradesList;
        }

        public static void AddAppliedUpgradesList(Upgrade newUpgrade)
        {
            appliedUpgradesList.Add(newUpgrade);
        }
    }
}