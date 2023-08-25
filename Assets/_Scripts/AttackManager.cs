using System.Threading.Tasks;
using _Scripts.Data;
using _Scripts.TurnSystem;
using UnityEngine;

namespace _Scripts
{
    public class AttackManager : MonoBehaviour
    {
        private Player _player;
        private Enemy _enemy;

        [SerializeField] private TurnManager _turnManager;

        private void Start()
        {
            _player = _turnManager._player;
            _enemy = _turnManager._enemies[0];
        }

        public async Task<bool> PerformAttack(AttackType attackType, Character target = null)
        {
            target ??= _enemy;

            if (target is Enemy)
            {
                Debug.Log("Waiting for player attack");
                await PerformPlayerAttack(_player, target, attackType);
                Debug.Log("After waiting for player attack");
            }
            else
            {
                await PerformEnemyAttack(_enemy, target, attackType);
            }

            return true;
        }


        private async Task PerformPlayerAttack(Character attacker, Character target, AttackType attackType)
        {
            attacker.Attack(target, attackType);
            await Task.Delay(2000);
            _turnManager.onTurnEnd?.Invoke();
        }

        private async Task PerformEnemyAttack(Character attacker, Character target, AttackType attackType)
        {
            attacker.Attack(target, attackType);
            await Task.Delay(5000);
            _turnManager.onTurnEnd?.Invoke();
        }
    }
}