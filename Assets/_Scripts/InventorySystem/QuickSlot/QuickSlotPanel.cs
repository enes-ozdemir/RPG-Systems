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

        public event Action<ItemSlot[]> OnQuickSlotChanged;

        private void OnEnable()
        {
            OnQuickSlotChanged += SetItems;
        }

        private void SetItems(ItemSlot[] itemSlots)
        {
            var itemList = new List<Item>();
            foreach (var itemSlot in itemSlots)
            {
                itemList.Add(itemSlot.Item);
            }
            DataManager.SetQuickSlotItems(itemList);
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            SetItems(itemSlots);

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

        private void OnValidate()
        {
            itemSlots = quickSlotParent.GetComponentsInChildren<QuickSlot>();
        }

        // public override bool AddItem(Item item, out Item previousItem)
        // {
        //     foreach (var slot in quickSlots)
        //     {
        //         previousItem = slot.Item;
        //         slot.Item = item;
        //         slot.Amount = slot.Amount;
        //         return true;
        //     }
        //
        //     previousItem = null;
        //     return false;
        // }

        public override bool AddItem(Item item)
        {
            OnQuickSlotChanged?.Invoke(itemSlots);
            return base.AddItem(item);
        }

        public override bool RemoveItem(Item item)
        {
            foreach (var slot in itemSlots)
            {
                if (slot.Item != item) continue;

                if (slot.Amount > 0)
                {
                    slot.Amount--;
                    if (slot.Amount == 0)
                    {
                        slot.Item = null;
                    }
                }
                else
                {
                    slot.Item = null;
                }

                OnQuickSlotChanged?.Invoke(itemSlots);
                return true;
            }

            return false;
        }
    }
}