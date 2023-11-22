using Enca.SaveSystem;
using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "CharData", menuName = "CharData/CharData")]
    public class CharData : SaveData
    {
        public string name;
        public int level;
        public Stats stats;
        public Ability[] abilities;

        public void SetCharacter(string name, int level, Stats stats)
        {
            this.name = name;
            this.level = level;
            this.stats = stats;
        }
    }
}