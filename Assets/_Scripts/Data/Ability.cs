using System.Threading.Tasks;
using _Scripts.DotweenController;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Ability")]
    public class Ability : ScriptableObject
    {
        public string abilityName;
        public int power;
        public float cooldown;
        public AttackType abilityType;
        public GameObject abilityPrefab;
        public Sprite abilitySprite;
        public Vector3 startOffSet;
        public AnimationBehaviour[] animations;

        public async Task PlayAbilityAnimation(Transform skillTransform,Transform targetTransform)
        {
            var animationSequenceController = new AnimationSequenceController(skillTransform,targetTransform);
            var seq = animationSequenceController.StartAnimation(animations);
            await seq.AsyncWaitForCompletion();
        }
    }
}