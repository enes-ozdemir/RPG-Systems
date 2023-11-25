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
        public Action onAttackEnd;

        public AttackManager(Character attacker, Character target)
        {
            _attacker = attacker;
            _target = target;
        }

        public async Task PerformAttack(Ability ability)
        {
            if (ability.abilityType is AttackType.HighAttack or AttackType.MiddleAttack or AttackType.LowAttack)
            {
                await PerformAttackWithMovement(ability);
            }
            else
            {
                await PerformAttackWithOutMovement(ability);
            }
        }

        private async Task PerformAttackWithMovement(Ability ability)
        {
            var position = _attacker.attackPos.position;
            _attacker.transform.DOMoveX(position.x, 0.3f);
            await Task.Delay(300);
            await _attacker.Attack(_target, ability);
            await Task.Delay(500);
            _attacker.transform.DOMoveX(_attacker.originalPos.x, 0.3f);
            await Task.Delay(300);
            onAttackEnd?.Invoke();
        }

        private async Task PerformAttackWithOutMovement(Ability ability)
        {
            await Task.Delay(100);
            await _attacker.Attack(_target, ability);
            await Task.Delay(500);
            onAttackEnd?.Invoke();
        }
    }
}