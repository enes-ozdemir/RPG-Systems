using System;
using _Scripts.Data;
using _Scripts.TurnSystem;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class FightUIManager : MonoBehaviour
    {
        [SerializeField] private TurnManager _turnManager;

        public Action onFightUIStart;
        public Action onFightUIEnd;
        public Action onPlayerTurnStart;
        public Action onEnemyTurnStart;
        public Action<AttackType> onPlayerAttack;

        [SerializeField] private TextMeshProUGUI turnText;
        [SerializeField] private GameObject fightUI;

        private void OnEnable()
        {
            _turnManager.onGameStart += StartUI;
            _turnManager.onPlayerTurnStart += SetUIForPlayer;
            _turnManager.onEnemyTurnStart += SetUIForEnemy;
            _turnManager.onGameOver += EndUI;
            onPlayerAttack += PlayerPerformedAttack;
        }

        private async void PlayerPerformedAttack(AttackType attackType)
        {
            SetUIForEnemy();
            await _turnManager.PlayerActionTaken(attackType);
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