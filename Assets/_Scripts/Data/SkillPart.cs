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
        public bool shouldRotate = false;

        public void RotateAnimation()
        {
            if(!shouldRotate) return;
            abilityPrefab.transform.localScale = new Vector3(abilityPrefab.transform.localScale.x * -1,
                abilityPrefab.transform.localScale.y, abilityPrefab.transform.localScale.z);

            // foreach (var animationBehaviour in animations)
            // {
            //     animationBehaviour.positionOffset.x *= -1;
            // }
        }
        
        public void MergeSeq(Sequence sequence)
        {
            var new_sequence = DOTween.Sequence();
            new_sequence.Join(sequence);
            new_sequence.Join(_sequence);
        }

        public async Task PlayAbilityAnimation(Transform skillTransform, Vector3 targetPos)
        {
            Debug.Log($"{targetPos} Enes");
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