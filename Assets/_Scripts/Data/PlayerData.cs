using System;
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
        
        public string playerName;
        public int playerLevel;
        public int playerExperience;
        public int playerGold;

        public Action<int> goldEarned;
        public Action<int> goldLost;

        public void AddGold(int amount)
        {
            playerGold += amount;
            goldEarned?.Invoke(amount);
        }
        public void SubstractGold(int amount)
        {
            playerGold-= amount;
            goldLost?.Invoke(amount);
        }

        //todo add abilities
        public void SetCharacter(List<EquippableItem> equipment, Item[] quickSlotItems)
        {
            this.equipment = equipment;
            this.quickSlotItems = quickSlotItems;
        }
    }
}