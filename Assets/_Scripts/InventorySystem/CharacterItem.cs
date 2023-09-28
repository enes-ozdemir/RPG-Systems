using _Scripts.Data;
using CharacterCreator2D;

namespace _Scripts.InventorySystem
{
    public class CharacterItem
    {
        public string name;
        public int level;
        public Stats stats;
        public Part part;

        public CharacterItem(string name, int level, Stats stats, Part part)
        {
            this.name = name;
            this.level = level;
            this.stats = stats;
            this.part = part;
        }
    }
}