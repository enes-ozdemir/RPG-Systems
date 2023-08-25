using System;
using System.Threading.Tasks;
using _Scripts.Data;
using UnityEngine;

namespace _Scripts.TurnSystem
{
    public class TurnManager : MonoBehaviour
    {
        private int _currentTurn;
        public Enemy[] _enemies;

        public Action onPlayerTurnStart;
        public Action onEnemyTurnStart;
        public Action onGameOver;
        public Action onGameStart;
        public Action onTurnEnd;
        public Action onTurnStart;

        public Player _player;
        private int _turnIndex;

        private void OnEnable()
        {
            onTurnEnd+=NextTurn;
        }

        private void Awake()
        {
            _player = new Player("Enca", 1, new Stats(10000
                , 10, 10, 10, 10
                , 10), new Ability[0]);
            var enemy = new Enemy("Enemy, 1", 1, new Stats(10000
                , 10, 10, 10, 10
                , 10), new Ability[0]);

            _enemies = new Enemy[1];
            _enemies[0] = enemy;
            

            StartTurn();
            _currentTurn = 0;
            onGameStart.Invoke();
        }

        private void StartTurn()
        {
            onTurnStart?.Invoke();

            if (_turnIndex == 0)
            {
                Debug.Log("Player Turn");
                SetPlayerTurn();
            }
            else if (_turnIndex == 1)
            {
                Debug.Log("Enemy Turn");
                SetEnemyTurn();
            }
        }

        private void NextTurn()
        {
            _currentTurn++;

            if (_player.IsDead() || _enemies[0].IsDead())
            {
                EndGame();
                return;
            }

            IncreaseTurnIndex();
            StartTurn();
        }

        private void IncreaseTurnIndex()
        {
            _turnIndex++;
            if (_turnIndex > 1)
                _turnIndex = 0;
        }

        private void EndGame()
        {
            onGameOver?.Invoke();
            // You can put any code here that needs to be executed at the end of the game, such as displaying a game over screen or resetting the game state.
            Debug.Log("Game Over!"); // Example: Log a game over message
        }

        private void SetPlayerTurn()
        {
            onPlayerTurnStart.Invoke();
            // This method could be responsible for enabling player controls, displaying UI elements for the player's turn, etc.
            //  _characters[_currentTurn].EnableControls(); // Example: Enable the player's controls
        }

        private async Task SetEnemyTurn()
        {
            onEnemyTurnStart.Invoke();
            await _enemies[0].Attack(_player, AttackType.LowAttack);
            NextTurn();

            // This method could handle the logic for an enemy's turn, such as triggering AI behaviors.
            // _characters[_currentTurn].PerformAIAction(); // Example: Trigger an AI action for the enemy
        }
    }
}