using _Scripts.Data;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "New Monster", menuName = "Monsters/Monster")]
    public class Monster : ScriptableObject
    {
        public string monsterName;
        public int health;
        public int attack;
        public Ability[] abilities; // Array of abilities that this monster has
        // Other stats for the monster
       
    }
}