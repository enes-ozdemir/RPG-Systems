using System.Threading.Tasks;
using _Scripts.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.UI.AttackButtons
{
    public abstract class AttackButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler
    {
        private Button _attackButton;
        [SerializeField] protected bool isActive = true;
        [SerializeField] private FightUIManager uiManager;
        [SerializeField] protected Ability ability;

        //todo listen an event here for active

        private void OnEnable()
        {
            uiManager.onPlayerTurnStart += SetActive;
            uiManager.onEnemyTurnStart += SetInActive;
        }

        private void OnDestroy()
        {
            uiManager.onPlayerTurnStart -= SetActive;
            uiManager.onEnemyTurnStart -= SetInActive;
        }

        private void OnValidate()
        {
            _attackButton = GetComponent<Button>();
        }

        private void Start()
        {
            _attackButton.onClick.AddListener(async () => await OnAttackButtonClicked());
        }

        private async  Task OnAttackButtonClicked()
        {
            Debug.Log("Attack Button Clicked");
            uiManager.onPlayerAttack.Invoke(ability);
            //  await _attackManager.PerformAttack(meleeAttackType);

            //todo attack
            //todo give turn
        }

        public void SetActive() => isActive = true;
        public void SetInActive() => isActive = false;

        public void SetActive(bool isActive)
        {
            this.isActive = isActive;
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (!isActive) return;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (!isActive) return;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (!isActive) return;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (!isActive) return;
        }
    }
}