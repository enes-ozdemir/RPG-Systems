using System;

namespace _Scripts.Data
{
    [Serializable]
    public class Stats
    {
        public int health;
        public int intelligence;
        public int strength;
        public int dexterity; //Todo dodge
        public int armor;
        public int magicResist;
        public int mana; //todo delete later or calculate from int

        public Stats(int health, int intelligence, int strength, int dexterity, int armor, int magicResist)
        {
            this.health = health;
            this.intelligence = intelligence;
            this.strength = strength;
            this.dexterity = dexterity;
            this.armor = armor;
            this.magicResist = magicResist;
        }
    }
}