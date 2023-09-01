using System;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Ability")]
    public class Ability : ScriptableObject
    {
        public string abilityName;
        public int power;
        public float cooldown;
        public AttackType abilityType;
        public Sprite abilitySprite;
        public Vector3 startOffSet;
        public bool isOnEnemy;
        public SkillPart[] skillParts;

        public Action<float> onDamageTime;

        private async Task PlayAbilityAnimation(Transform playerTransform, Transform targetTransform)
        {
            Sequence savedSequence = null;
            var initialPos = playerTransform.position + startOffSet;
            if (isOnEnemy) initialPos = targetTransform.position + startOffSet;
            for (var i = 0; i < skillParts.Length; i++)
            {
                CheckIfAnimEnding(i);

                var skillPart = skillParts[i];

                var skill = Instantiate(skillPart.abilityPrefab, initialPos, quaternion.identity);

                if (savedSequence != null)
                {
                    skillPart.MergeSeq(savedSequence);
                }

                var seq = skillPart.PlayAbilityAnimation(skill.transform,
                    targetTransform.position);
                await seq; //enemy offset
                initialPos = skill.transform.position;

                if (skillPart.joinNextSequence)
                {
                    savedSequence = skillPart.GetSequence();
                }
                else
                {
                    skill.gameObject.SetActive(false);
                    //Destroy(skill);
                }
            }
        }

        private void CheckIfAnimEnding(int i)
        {
            if (i + 1 == skillParts.Length)
            {
                onDamageTime?.Invoke(skillParts[i].GetLastAnimationDuration());
            }
        }

        public async Task CreateAbility(Transform playerTransform, Transform targetTransform)
        {
            await PlayAbilityAnimation(playerTransform, targetTransform);
        }
    }
}