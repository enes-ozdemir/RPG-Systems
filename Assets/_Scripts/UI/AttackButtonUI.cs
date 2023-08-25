using System.Threading.Tasks;
using _Scripts.Data;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class AttackButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
        IPointerUpHandler
    {
        [SerializeField] private Image weaponImage;
        [SerializeField] private Image borderImage;

        [SerializeField] private Sprite blockedSprite;
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite highlightSprite;

        [SerializeField] private Button attackButton;
        [SerializeField] private Vector2 highlightOffset; // Direction offset to apply when highlighted

        [SerializeField] private bool _isActive = true;
        [SerializeField] private float duration;

        [SerializeField] private FightUIManager _uiManager;
        [SerializeField] private AttackManager _attackManager;
        [SerializeField] private AttackType meleeAttackType;

        //todo listen an event here for active
        private Vector2 _originalPosition; // to store the original position

        private void OnEnable()
        {
            _uiManager.onPlayerTurnStart += SetActive;
            _uiManager.onEnemyTurnStart += SetInActive;
        }

        private void OnDisable()
        {
            _uiManager.onPlayerTurnStart -= SetActive;
            _uiManager.onEnemyTurnStart -= SetInActive;
        }

        private void OnValidate()
        {
            attackButton = GetComponent<Button>();
        }

        private void Start()
        {
            _originalPosition = weaponImage.rectTransform.anchoredPosition; // Store the original position
            attackButton.onClick.AddListener(async () => await OnAttackButtonClicked());
        }

        private async Task OnAttackButtonClicked()
        {
            Debug.Log("Attack Button Clicked");
            await _attackManager.PerformAttack(meleeAttackType);

            //todo attack
            //todo give turn
        }


        private void SetHighlight(bool isHighlighted)
        {
            if (isHighlighted)
            {
                borderImage.sprite = highlightSprite;
                weaponImage.rectTransform.DOAnchorPos(_originalPosition + highlightOffset, duration)
                    .SetLoops(-1, LoopType.Yoyo) // Infinite loops with Yoyo effect
                    .SetEase(Ease.InOutSine);
            }
            else
            {
                weaponImage.rectTransform.DOKill(false);
                borderImage.sprite = normalSprite;
                weaponImage.rectTransform.anchoredPosition = _originalPosition;
            }
        }

        public void SetActive() => _isActive = true;
        public void SetInActive() => _isActive = false;

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
            borderImage.sprite = isActive ? normalSprite : blockedSprite;
        }

        // Called when the pointer enters the button
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_isActive) return;
            SetHighlight(true);
        }

        // Called when the pointer exits the button
        public void OnPointerExit(PointerEventData eventData)
        {
            if (!_isActive) return;
            SetHighlight(false);
        }

        // Called when the pointer is down on the button (e.g. finger pressing on phone)
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isActive) return;
            SetHighlight(true);
        }

        // Called when the pointer is up on the button (e.g. finger releasing on phone)
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isActive) return;
            SetHighlight(false);
        }
    }
}