using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Scripts.Data;
using UnityEngine;

namespace _Scripts.TurnSystem
{
    public class TurnManager : MonoBehaviour
    {
        private int _currentTurn;
        public Action onPlayerTurnStart;
        public Action onEnemyTurnStart;
        public Action onGameOver;
        public Action onGameStart;
        public Action onTurnEnd;
        public Action onTurnStart;

        public Player _player;
        public List<Enemy> enemies;
        public Enemy currentEnemy;
        private int _turnIndex;

        private AttackManager _playerAttackManager;
        private AttackManager _enemyAttackManager;
        private TaskCompletionSource<bool> _playerActionTcs;

        private void OnEnable()
        {
            _playerAttackManager.onAttackEnd += NextTurn;
            _enemyAttackManager.onAttackEnd += NextTurn;
        }

        private void OnDisable()
        {
            _playerAttackManager.onAttackEnd -= NextTurn;
            _enemyAttackManager.onAttackEnd -= NextTurn;
        }

        private void Awake()
        {
            currentEnemy = enemies[0];
            _player.SetCharacter("Player", 100, new Stats(100, 10, 10, 10, 10, 10) );
            currentEnemy.SetCharacter("Enemy", 100, new Stats(100, 10, 10, 10, 10, 10));
            _playerAttackManager = new AttackManager(_player, currentEnemy); //todo next enemye geçince değiş
            _enemyAttackManager = new AttackManager(currentEnemy, _player); //todo next enemye geçince değiş
        }

        private void Start()
        {
            _player.PlayAnimation(AnimationType.Idle);
            currentEnemy.PlayAnimation(AnimationType.Idle);

            StartTurn();
            _currentTurn = 0;
            onGameStart.Invoke();
        }

        private async Task StartTurn()
        {
            onTurnStart?.Invoke();

            if (_turnIndex == 0)
            {
                Debug.Log("Player Turn");
                await SetPlayerTurn();
            }
            else if (_turnIndex == 1)
            {
                Debug.Log("Enemy Turn");
                await SetEnemyTurn(currentEnemy.abilities[0]);  //todo get it from ai laiter;
            }
        }

        private async void NextTurn()
        {
           onTurnEnd?.Invoke();
            
            _currentTurn++;

            if (_player.IsDead() || enemies[0].IsDead())
            {
                EndGame();
                return;
            }

            IncreaseTurnIndex();
            await StartTurn();
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


        private async Task SetPlayerTurn()
        {
            onPlayerTurnStart.Invoke();
    
            _playerActionTcs = new TaskCompletionSource<bool>();
    
            // Enable any UI buttons or controls, and wire up their 'onClick' to call `PlayerActionTaken()`
            Debug.Log("wait for player input");

            await _playerActionTcs.Task;

            Debug.Log("Player Turn End");
            // Continue with your code
        }

        public async Task PlayerActionTaken(Ability ability)
        {
            // Disable any UI buttons or controls
            await _playerAttackManager.PerformAttack(ability);
            _playerActionTcs.SetResult(true);
        }

        private async Task SetEnemyTurn(Ability ability)
        {
            onEnemyTurnStart.Invoke();
            await _enemyAttackManager.PerformAttack(ability);

            // This method could handle the logic for an enemy's turn, such as triggering AI behaviors.
            // _characters[_currentTurn].PerformAIAction(); // Example: Trigger an AI action for the enemy
        }
    }
}