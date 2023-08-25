using System;
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

        [SerializeField] private TextMeshProUGUI turnText;

        private void OnEnable()
        {
            _turnManager.onGameStart += StartUI;
            _turnManager.onPlayerTurnStart += SetUIForPlayer;
            _turnManager.onEnemyTurnStart += SetUIForEnemy;
            _turnManager.onGameOver += EndUI;
        }

        private void OnDisable()
        {
            _turnManager.onGameStart -= StartUI;
            _turnManager.onPlayerTurnStart -= SetUIForPlayer;
            _turnManager.onEnemyTurnStart -= SetUIForEnemy;
            _turnManager.onGameOver -= EndUI;
        }

        public void EndUI() => onFightUIEnd?.Invoke();

        public void SetUIForEnemy()
        {
            onEnemyTurnStart.Invoke();
            turnText.text = "Enemy Turn";
        }

        public void StartUI() => onFightUIStart?.Invoke();

        public void SetUIForPlayer()
        {
            onPlayerTurnStart.Invoke();
            turnText.text = "Player Turn";
        }
    }
}