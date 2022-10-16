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
            characterSkill.ChangeSkill(newSkill);
        }
    }
}
