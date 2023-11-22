using System.Collections.Generic;
using _Scripts.InventorySystem;
using Enca.SaveSystem;
using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "CharData/PlayerData")]
    public class PlayerData : SaveData
    {
        public List<EquippableItem> equipment;
        public Item[] quickSlotItems;

        //todo add abilities
        public void SetCharacter(List<EquippableItem> equipment, Item[] quickSlotItems)
        {
            this.equipment = equipment;
            this.quickSlotItems = quickSlotItems;
        }
    }
}