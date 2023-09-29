using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    public class CharacterInventory : ItemContainer
    {
        [SerializeField] private List<EquippableItem> startingItems;
        [SerializeField] private Transform itemParent;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvent;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;
        public event Action<BaseItemSlot> OnShiftRightClickEvent;
        public event Action<BaseItemSlot> onBuyEvent;

        private void Start()
        {
            foreach (var slot in itemSlots)
            {
                slot.OnPointerEnterEvent += OnPointerEnterEvent;
                slot.OnPointerExitEvent += OnPointerExitEvent;
                slot.OnBeginDragEvent += OnBeginDragEvent;
                slot.OnEndDragEvent += OnEndDragEvent;
                slot.OnDropEvent += OnDropEvent;
                slot.OnDragEvent += OnDragEvent;
                slot.OnShiftRightClickEvent += OnShiftRightClickEvent;
            }
            // SetStartingItems();
        }

        private void OnValidate()
        {
            itemSlots = itemParent.GetComponentsInChildren<EquipmentSlot>();
            //  SetStartingItems();
        }

        private void SetStartingItems()
        {
            var i = 0;
            for (; i < startingItems.Count && i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = startingItems[i].GetCopy();
                itemSlots[i].Amount = 1;
            }

            for (; i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = null;
                itemSlots[i].Amount = 0;
            }
        }
    }
}