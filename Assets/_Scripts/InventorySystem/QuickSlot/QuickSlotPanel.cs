using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.InventorySystem.QuickSlot
{
    public class QuickSlotPanel : ItemContainer
    {
        [SerializeField] private Transform quickSlotParent;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvent;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;

        public Action<QuickSlot[]> OnQuickSlotChanged;
        public Action<Item> OnQuickSlotItemAdded;
        public Action<Item> OnQuickSlotItemRemoved;

        private readonly List<Item> _itemList = new List<Item>();

        private void OnValidate()
        {
            itemSlots = quickSlotParent.GetComponentsInChildren<QuickSlot>();
        }

        private void OnEnable()
        {
            //  OnQuickSlotChanged += SetItems;
            OnQuickSlotItemAdded += AddNewItem;
            OnQuickSlotItemRemoved += AddNewItem;
        }

        private void OnDisable()
        {
            //OnQuickSlotChanged -= SetItems;
            OnQuickSlotItemAdded -= AddNewItem;
            OnQuickSlotItemRemoved -= RemoveNewItem;
        }

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
            }
        }

        private void RemoveNewItem(Item item)
        {
            _itemList.Remove(item);
            OnQuickSlotChanged?.Invoke(itemSlots as QuickSlot[]);
        }

        private void AddNewItem(Item item)
        {
            _itemList.Add(item);
            OnQuickSlotChanged?.Invoke(itemSlots as QuickSlot[]);
        }

        public override bool AddItem(Item item)
        {
            Debug.Log($"Item added {item.itemName}");
            _itemList.Add(item);
            OnQuickSlotChanged?.Invoke(itemSlots as QuickSlot[]);
            return true;
        }

        public virtual void OverrideQuickSlotItems(Item[] itemList)
        {
            for (var i = 0; i < itemList.Length; i++)
            {
                var item = itemList[i];
                if (item != null)
                {
                    ((QuickSlot)itemSlots[i]).AddItemToSlot(item);
                    ((QuickSlot)itemSlots[i]).Amount = 1;
                }
            }
        }

        public override bool RemoveItem(Item item)
        {
            foreach (var slot in itemSlots)
            {
                if (slot.Item != item) continue;
                slot.Item = null;
                _itemList.Remove(item);
            }

            OnQuickSlotChanged?.Invoke(itemSlots as QuickSlot[]);
            return true;
        }
    }
}