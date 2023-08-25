using System;
using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Data
{
    public abstract class Character
    {
        public string name;
        public int level;
        public Stats stats;
        public Ability[] abilities;

        public Character(string name, int level, Stats stats, Ability[] abilities)
        {
            this.name = name;
            this.level = level;
            this.stats = stats;
            this.abilities = abilities;
        }

        public void TakeDamage(int damage)
        {
            Debug.Log(this.name + " takes " + damage + " damage");
            stats.health -= damage;
        }

        public async Task Attack(Character target, AttackType attackType)
        {
            Debug.Log(this.name + " attacks " + target.name);
            int damage = 0;

            switch (attackType)
            {
                case AttackType.HighAttack:
                    damage = stats.strength * 4;
                    break;
                case AttackType.MiddleAttack:
                    damage = stats.strength * 3;
                    break;
                case AttackType.LowAttack:
                    damage = stats.strength * 2;
                    break;
                case AttackType.RangeAttack:
                    break;
                case AttackType.MagicAttack:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null);
            }

            await Task.Delay(2000);
            target.TakeDamage(damage);
        }

        public bool IsDead() => stats.health <= 0;
    }
}