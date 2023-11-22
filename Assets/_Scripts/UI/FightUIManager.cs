using System;
using System.Linq;
using _Scripts.Data;
using _Scripts.InventorySystem.QuickSlot;
using _Scripts.TurnSystem;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class FightUIManager : MonoBehaviour
    {
        [SerializeField] private TurnManager _turnManager;
        [SerializeField] private QuickSlotPanel _quickSlotPanel;

        public Action onFightUIStart;
        public Action onFightUIEnd;
        public Action onPlayerTurnStart;
        public Action onEnemyTurnStart;
        public Action<Ability> onPlayerAttack;

        [SerializeField] private TextMeshProUGUI turnText;
        [SerializeField] private GameObject fightUI;
        [SerializeField] private GameObject skillUI;

        private void OnEnable()
        {
            _turnManager.onGameStart += StartUI;
            _turnManager.onPlayerTurnStart += SetUIForPlayer;
            _turnManager.onEnemyTurnStart += SetUIForEnemy;
            _turnManager.onGameOver += EndUI;
            onPlayerAttack += PlayerPerformedAttack;
        }

        private void Start()
        {
            InitQuickSlot();
        }

        private void InitQuickSlot()
        {
            // Debug.Log("InitQuickSlot called in FightUI");
            // var quickSlotItems = SceneDataManager._playerData.quickSlotItems;
            // if (quickSlotItems==null) return;
            // _quickSlotPanel.AddItems(quickSlotItems.ToArray());
        }

        private async void PlayerPerformedAttack(Ability ability)
        {
            SetUIForEnemy();
            await _turnManager.PlayerActionTaken(ability);
        }

        private void OnDisable()
        {
            _turnManager.onGameStart -= StartUI;
            _turnManager.onPlayerTurnStart -= SetUIForPlayer;
            _turnManager.onEnemyTurnStart -= SetUIForEnemy;
            _turnManager.onGameOver -= EndUI;
            onPlayerAttack -= PlayerPerformedAttack;
        }

        public void EndUI() => onFightUIEnd?.Invoke();

        public void SetUIForEnemy()
        {
            fightUI.SetActive(false);
            onEnemyTurnStart?.Invoke();
            turnText.text = "Enemy Turn";
        }

        public void StartUI() => onFightUIStart?.Invoke();

        public void SetUIForPlayer()
        {
            onPlayerTurnStart.Invoke();
            fightUI.SetActive(true);
            turnText.text = "Player Turn";
        }
    }
}