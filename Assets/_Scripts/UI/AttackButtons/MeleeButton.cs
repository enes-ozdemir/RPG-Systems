using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.UI.AttackButtons
{
    public class MeleeButton : AttackButtonUI
    {
        [SerializeField] private Image weaponImage;
        [SerializeField] private Image borderImage;
        [SerializeField] private Vector2 highlightOffset;
        private Vector2 _originalPosition;
        [SerializeField] private float duration;

        private void Awake()
        {
            _originalPosition = weaponImage.rectTransform.anchoredPosition;
        }

        private void SetHighlight(bool isHighlighted)
        {
            if (isHighlighted)
            {
                weaponImage.rectTransform.DOAnchorPos(_originalPosition + highlightOffset, duration)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
            }
            else
            {
                weaponImage.rectTransform.DOKill(false);
                weaponImage.rectTransform.anchoredPosition = _originalPosition;
            }
        }

        #region PointerRegion

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (!isActive) return;
            SetHighlight(true);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (!isActive) return;
            SetHighlight(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (!isActive) return;
            SetHighlight(true);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (!isActive) return;
            SetHighlight(false);
        }

        #endregion
    }
}