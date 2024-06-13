using _Scripts.Data;
using UnityEngine;

namespace _Scripts
{
    public class RpgUtil
    {
        private static readonly string[] ItemNames = new string[]
        {
            "Sword of Eternal Flames",
            "Gauntlets of the Wind Walker",
            "Helm of the Ocean's Call",
            "Amulet of Arcane Mastery",
            "Staff of Eldritch Power",
            "Shield of the Stone Titan",
            "Dagger of the Whispering Shadows",
            "Greaves of the Moonlight Stalker",
            "Cloak of the Phoenix Feather",
            "Ring of Divine Blessings",
            "Quiver of the Eternal Hunter",
            "Tome of the Forgotten Spells",
            "Potion of Celestial Healing",
            "Scepter of the Ice Queen",
            "Girdle of Thunderous Might",
            "Boots of the Fleetfooted Nomad",
            "Gloves of the Alchemist's Touch",
            "Lantern of the Soul Guide",
            "Bracers of the Sun's Wrath",
            "Mace of the Fallen Paladin",
            "Wand of Temporal Distortion",
            "Orb of the Abyssal Depths"
        };

        public static string GetRandomItemName()
        {
            var index = Random.Range(0, ItemNames.Length);
            return ItemNames[index];
        }

        public static int GetItemLevelForDrop(int level)
        {
            int minLevel = 1;
            if (level >= 4)
            {
                minLevel = level - 3;
            }

            int itemLevel = Random.Range(minLevel, level + 3);
            return itemLevel;
        }

        // public static Stats GetRandomStats(int level)
        // {
        //     var rand = new System.Random();
        //
        //     int health = rand.Next(50, 100) * level;
        //     int mana = rand.Next(20, 50) * level;
        //     int attackDamage = rand.Next(10, 20) * level;
        //     float attackSpeed = (float) (rand.Next(1, 3) + rand.NextDouble()); 
        //     int armor = rand.Next(5, 10) * level;
        //     int magicResist = rand.Next(5, 10) * level;
        //     int movementSpeed = rand.Next(3, 8);
        //     int dodgeCooldown = rand.Next(2, 5) * 1/level;
        //
        //     return new Stats(health, mana, attackDamage, attackSpeed, armor, magicResist, movementSpeed,dodgeCooldown);
        // }
        public static Stats GetRandomStatsForItem(int playerLevel)
        {
            //todo fill this
            return new Stats(10, 10, 10, 10, 10, 10);
        }
    }
}