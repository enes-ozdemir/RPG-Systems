using System;

namespace _Scripts.Data
{
    [Serializable]
    public class CharData
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