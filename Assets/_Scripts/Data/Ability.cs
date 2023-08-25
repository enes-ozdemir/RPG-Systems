using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Ability")]
    public class Ability : ScriptableObject
    {
        public string abilityName;
        public int power;
        public float cooldown;
        public AbilityType abilityType;
        // Other properties for the ability
    }

    public enum AbilityType
    {
        DirectSkill,SkillFromUp,SkillFromDown,
        Buff,Debuf,
    }
}