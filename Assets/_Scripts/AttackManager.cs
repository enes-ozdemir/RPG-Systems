using System;
using System.Threading.Tasks;
using _Scripts.Data;
using DG.Tweening;

namespace _Scripts
{
    public class AttackManager
    {
        private readonly Character _attacker;
        private readonly Character _target;
        
        public AttackManager(Character attacker,Character target)
        {
            _attacker = attacker;
            _target = target;
        }
        
        public Action onAttackEnd;

        public async Task PerformAttack(AttackType attackType)
        {
            await PerformAttackWithAnimation(attackType);
        }

        private async Task PerformAttackWithAnimation(AttackType attackType)
        {
            var position = _attacker.attackPos.position;
            _attacker.transform.DOMove(position, 0.3f);
            await Task.Delay(300);
            await _attacker.Attack(_target, attackType);
            await Task.Delay(500);
            _attacker.transform.DOMove(_attacker.originalPos, 0.3f);
            await Task.Delay(300);
            onAttackEnd?.Invoke();
        }
    }
}