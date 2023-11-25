using System;
using System.Threading.Tasks;
using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Data
{
    public class Character : MonoBehaviour
    {
        private Animator _animator;
        public Transform attackPos;
        public CharData charData;
        private Character _currentTarget;
         public Vector3 originalPos;
        [SerializeField] private StatusBar healthBar;
        [SerializeField] private StatusBar manaBar;

        private int _health;
        private int _mana;

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
            originalPos = transform.localPosition;
        }

        private void Start()
        {
            _health = charData.stats.health;
            healthBar.SetAmount(_health, charData.stats.health);
            manaBar.SetAmount(_mana, charData.stats.mana);
        }

        public void PlayAnimation(AnimationType animationType, AttackType attackType = AttackType.HighAttack)
        {
            switch (animationType)
            {
                case AnimationType.Idle:
                    _animator.Play("Idle");
                    break;
                case AnimationType.Attack:
                    switch (attackType)
                    {
                        //Todo Attack Punch 1 2 3
                        //Todo Attack Kick 1 2


                        case AttackType.HighAttack:
                            _animator.Play("Attack Main Hand 1");
                            break;
                        case AttackType.MiddleAttack:
                            _animator.Play("Attack Main Hand 2");
                            break;
                        case AttackType.LowAttack:
                            _animator.Play("Attack Main Hand 3");
                            break;
                        case AttackType.Buff:
                            _animator.Play("Cast 1");
                            break;
                        case AttackType.DirectSkill:
                            _animator.Play("Attack Punch 1");
                            break;
                        case AttackType.SkillFromDown:
                            _animator.Play("Attack Kick 1");
                            break;
                        case AttackType.SkillFromUp:
                            _animator.Play("Cast 2");
                            break;
                        case AttackType.Debuf:
                            _animator.Play("Cast 1");
                            break;
                        default:
                            _animator.Play("Cast 2");
                            break;
                    }

                    break;
                case AnimationType.TakeDamage:
                    _animator.Play("Hit");
                    break;
                case AnimationType.Die:
                    _animator.Play("Die");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(animationType), animationType, null);
            }
        }

        private void TakeDamage(int damage)
        {
            Debug.Log(this.name + " takes " + damage + " damage");
            _health -= damage;
            healthBar.SetAmount(_health, charData.stats.health);
            PlayAnimation(AnimationType.TakeDamage);
        }

        public async Task Attack(Character target, Ability ability)
        {
            _currentTarget = target;
            Debug.Log(this.name + " attacks " + target.name);
            int damage = CalculateDamage(ability); // Calculate damage based on ability
            PlayAnimation(AnimationType.Attack, ability.abilityType);

            if (ability.abilityType is AttackType.HighAttack or AttackType.MiddleAttack or AttackType.LowAttack)
            {
                CalculateTimeAndDamage(1);
            }
            else
            {
                // Pass target's original position to CreateAbility and await the execution
                await ExecuteAbility(ability);
                // You can continue with other logic here without waiting for ability completion.
            }
        }

        private int CalculateDamage(Ability ability) => 10;

        private async Task ExecuteAbility(Ability ability)
        {
            manaBar.SetAmount(_mana, charData.stats.mana);

            ability.onDamageTime += CalculateTimeAndDamage;
            await ability.CreateAbility(transform, _currentTarget.transform);
            ability.onDamageTime -= CalculateTimeAndDamage;

            // switch (ability.abilityType)
            // {
            //     case AttackType.HighAttack:
            //         break;
            //     case AttackType.MiddleAttack:
            //         break;
            //     case AttackType.LowAttack:
            //         break;
            //     case AttackType.DirectSkill:
            //         await MoveSkillToTarget(skillInWorldSpace, targetOriginalPos, ability.abilitySpeed);
            //         break;
            //     case AttackType.SkillFromUp:
            //         break;
            //     case AttackType.SkillFromDown:
            //         break;
            //     case AttackType.Buff:
            //         break;
            //     case AttackType.Debuf:
            //         break;
            //     default:
            //         throw new ArgumentOutOfRangeException();
            // }
        }

        private async void CalculateTimeAndDamage(float lastSkillDuration)
        {
            var damageTime = (int)lastSkillDuration * 200;
            Debug.Log("Damage time: " + damageTime);
            await Task.Delay(damageTime);
            _currentTarget.TakeDamage(1);
        }

        public bool IsDead() => charData.stats.health <= 0;
    }

    public enum AnimationType
    {
        Idle,
        Attack,
        TakeDamage,
        Die
    }
}