using System;
using _Scripts.InventorySystem;
using UnityEngine;

namespace _Scripts
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] Inventory inventory;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void AddItemToInventory(Item item) => inventory.AddItem(item);
    }
}