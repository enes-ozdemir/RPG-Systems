using System;
using System.Collections.Generic;
using _Scripts.InventorySystem;
using UnityEngine;

namespace _Scripts
{
    public static class DataManager
    {
        private static List<Item> _quickSlotItems = new();
        private static List<Item> _droppedItems = new();

        public static List<Item> GetQuickSlotItems()
        {
            return _quickSlotItems;
        }
        
        public static void SetQuickSlotItems(List<Item> items)
        {
            Debug.Log("SetQuickSlotItems called");
            _quickSlotItems = items;
        }

        public static List<Item> GetDroppedItems()
        {
            return _droppedItems;
        }
        
        public static void SetDroppedItems(List<Item> items)
        {
            _droppedItems = items;

        }
    }
}