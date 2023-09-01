using System;
using System.Threading.Tasks;
using _Scripts.DotweenController;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "Skill Part", menuName = "Abilities/Skill Part")]
    public class SkillPart : ScriptableObject
    {
        public GameObject abilityPrefab;
        public AnimationBehaviour[] animations;
        public bool joinNextSequence = false;
        private Sequence _sequence;

        public void MergeSeq(Sequence sequence)
        {
            var new_sequence = DOTween.Sequence();
            new_sequence.Join(sequence);
            new_sequence.Join(_sequence);
        }

        public async Task PlayAbilityAnimation(Transform skillTransform, Vector3 targetPos)
        {
            
            var animationSequenceController = new AnimationSequenceController(skillTransform, targetPos);
            
            if (joinNextSequence)
            {
                _sequence = animationSequenceController.GetSeq(animations);
            }
            else
            {
                _sequence = animationSequenceController.StartAnimation(animations);
                await _sequence.AsyncWaitForCompletion();
            }
        }

        public Sequence GetSequence() => _sequence;

        public float GetLastAnimationDuration()
        {
            return animations[^1].duration;
        }
    }
}