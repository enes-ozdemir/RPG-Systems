using System;
using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Data
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public string name;
        public int level;
        public Stats stats;
        public Ability[] abilities;

        public Transform attackPos;
        [HideInInspector] public Vector3 originalPos;

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            originalPos = transform.position;
        }

        public void SetCharacter(string name, int level, Stats stats, Ability[] abilities)
        {
            this.name = name;
            this.level = level;
            this.stats = stats;
            this.abilities = abilities;
        }

        public void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.Idle:
                    _animator.Play("Idle");
                    break;
                case AnimationType.Attack:
                    _animator.Play("Attack Main Hand 1");

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

        public void TakeDamage(int damage)
        {
            Debug.Log(this.name + " takes " + damage + " damage");
            stats.health -= damage;
            PlayAnimation(AnimationType.TakeDamage);
        }

        public async Task Attack(Character target, AttackType attackType)
        {
            Debug.Log(this.name + " attacks " + target.name);
            int damage = 0;
            PlayAnimation(AnimationType.Attack);

            switch (attackType)
            {
                case AttackType.HighAttack:
                    damage = 4;
                    break;
                case AttackType.MiddleAttack:
                    damage = 3;
                    break;
                case AttackType.LowAttack:
                    damage =  2;
                    break;
                case AttackType.RangeAttack:
                    break;
                case AttackType.MagicAttack:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null);
            }

            target.TakeDamage(damage);
        }

        public bool IsDead() => stats.health <= 0;
    }

    public enum AnimationType
    {
        Idle,
        Attack,
        TakeDamage,
        Die
    }
}