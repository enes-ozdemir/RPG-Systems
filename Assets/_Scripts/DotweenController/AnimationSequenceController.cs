using DG.Tweening;
using UnityEngine;

namespace _Scripts.DotweenController
{
    public class AnimationSequenceController
    {
        private Sequence _sequence;
        private bool _sequenceTriggered;
        private Transform objectToTween;
        private Transform targetTransform;
        
        public AnimationSequenceController(Transform gameObjectToTween, Transform targetTransform)
        {
            objectToTween = gameObjectToTween;
            this.targetTransform = targetTransform;
        }

        public Sequence StartAnimation(AnimationBehaviour[] animations)
        {
            _sequence = DOTween.Sequence();
            SetTweenData(animations);
            BuildSequence(animations);
            _sequence.Play();
            return _sequence;
        }
        
        private void SetTweenData(AnimationBehaviour[] animations)
        {
            Tween tween;
            for (int i = 0; i < animations.Length; i++)
            {
                var setting = animations[i];
                var targetPosition = targetTransform.position + setting.positionOffset;
                switch (setting.tweenType)
                {
                    case TweenType.Move:
                        tween = objectToTween.DOMove(targetPosition - new Vector3(3,0,0),
                            setting.animationCurve.Evaluate(setting.duration));
                        animations[i].tween = tween;
                        break;
                    case TweenType.Scale:
                        tween = objectToTween.DOScale(setting.targetScale,
                            setting.animationCurve.Evaluate(setting.duration));
                        animations[i].tween = tween;
                        break;
                    case TweenType.Fade:
                        tween = objectToTween.GetComponent<MeshRenderer>().sharedMaterial
                            .DOFade(0, setting.animationCurve.Evaluate(setting.duration));
                        animations[i].tween = tween;
                        break;
                    case TweenType.Bounce:
                        tween = objectToTween.DOPunchScale(setting.positionOffset,
                            setting.animationCurve.Evaluate(setting.duration), (int)setting.targetScale, 2);
                        animations[i].tween = tween;
                        break;
                }
            }
        }

        private void BuildSequence(AnimationBehaviour[] animations)
        {
            _sequence.Pause();
            _sequence.SetAutoKill(false);
            for (var i = 0; i < animations.Length; i++)
            {
                if (animations[i].join)
                {
                    _sequence.Join(animations[i].tween);
                }
                else
                {
                    _sequence.Append(animations[i].tween);
                }
            }
        }
    }
}