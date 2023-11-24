using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

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

        private Item[] _itemList;

        private void Awake()
        {
            _itemList = new Item[itemSlots.Length];
        }

        private void OnValidate()
        {
            itemSlots = quickSlotParent.GetComponentsInChildren<QuickSlot>();
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

        public override bool AddItem(Item item)
        {
            Debug.Log($"Item added {item.itemName}");
            return true;
        }

        public virtual void OverrideQuickSlotItems(Item[] itemArray)
        {
            var slots = itemSlots as QuickSlot[];
            for (var i = 0; i < slots!.Length; i++)
            {
                var item = itemArray[i];
                if (item != null)
                {
                    ((QuickSlot)itemSlots[i]).AddItemToSlot(item);
                    ((QuickSlot)itemSlots[i]).Amount = 1;
                    _itemList[i] = item;
                }
            }
        }

        public override bool RemoveItem(Item item)
        {
            foreach (var slot in itemSlots)
            {
                if (slot.Item != item) continue;
                slot.Item = null;
            }

            return true;
        }

        public Item[] GetItems()
        {
            Item[] items = new Item[itemSlots.Length];
            for (int i = 0; i < itemSlots.Length; i++)
            {
                items[i] = itemSlots[i].Item;
            }

            return items;
        }
    }
}