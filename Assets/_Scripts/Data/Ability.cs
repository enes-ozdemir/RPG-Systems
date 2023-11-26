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
        public HitEffect hitEffect;

        public Action<float,HitEffect> onDamageTime;

        private async Task PlayAbilityAnimation(Transform startTransform, Transform targetTransform)
        {
            Sequence savedSequence = null;
            var initialPos = startTransform.position + startOffSet;
            if (isOnEnemy) initialPos = targetTransform.position + startOffSet;
            for (var i = 0; i < skillParts.Length; i++)
            {
                CheckIfAnimEnding(i);

                var skillPart = skillParts[i];
                Vector3 originalScale = skillPart.abilityPrefab.transform.localScale; // Store original scale
                HandleSkillRotation(startTransform, targetTransform, skillPart);

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
                skillPart.abilityPrefab.transform.localScale = originalScale;
            }

        }

        private void HandleSkillRotation(Transform startTransform, Transform targetTransform, SkillPart skillPart)
        {
            {
                if (startTransform.position.x > targetTransform.position.x)
                    skillPart.RotateAnimation();
            }
        }

        private void CheckIfAnimEnding(int i)
        {
            if (i + 1 == skillParts.Length)
            {
                onDamageTime?.Invoke(skillParts[i].GetLastAnimationDuration(),hitEffect);
            }
        }

        public async Task CreateAbility(Transform playerTransform, Transform targetTransform)
        {
            await PlayAbilityAnimation(playerTransform, targetTransform);
        }
    }
}