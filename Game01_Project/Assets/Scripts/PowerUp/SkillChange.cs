using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
    [CreateAssetMenu(menuName = "PowerUpSystem/Skill")]
    public class SkillChange : PowerUp
    {
        [SerializeField] private Skill newSkill;
        public override void Apply(Transform targetTransform)
        {
            CharacterSkill characterSkill = targetTransform.GetComponent<CharacterSkill>();
            if (!characterSkill.AbilityPermitted)
            {
                characterSkill.AbilityPermitted = true;
            }
            characterSkill.ChangeSkill(newSkill);
            Debug.Log("Skill Changed: " + characterSkill.currentSkill.name);
            PowerUpSelectionCompleted();
        }
    }
}
