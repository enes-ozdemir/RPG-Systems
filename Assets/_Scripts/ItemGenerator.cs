using _Scripts.InventorySystem;
using UnityEngine;

namespace _Scripts
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField] private PartContainer partContainer;

        public CharacterItem GenerateRandomItem(int playerLevel)
        {
            var itemName = RpgUtil.GetRandomItemName();
            var itemLevel = RpgUtil.GetItemLevelForDrop(playerLevel);
            var part = partContainer.GetRandomItem();
            var stats = RpgUtil.GetRandomStatsForItem(playerLevel);
            return new CharacterItem(itemName, itemLevel, stats, part);
        }

     
        
        
    }
}