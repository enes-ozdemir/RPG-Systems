using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.DotweenController
{
        [Serializable]
        public class AnimationBehaviour
        {
            [Header("Mandatory Fields*")] [Tooltip("Following Fields are mandatory for all tweenTypes")]

            public float duration;
            public bool join;
            public TweenType tweenType;
            public AnimationCurve animationCurve;
            [Header("Move / Bounce")] public Vector3 positionOffset;
            [Header("Scale / Bounce")] public float targetScale;
            [HideInInspector] public Tween tween;

          
            
        }
}