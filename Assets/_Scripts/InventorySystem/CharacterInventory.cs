using System;
using System.Collections.Generic;
using CharacterCreator2D;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    public class CharacterInventory : ItemContainer
    {
        [SerializeField] private List<EquippableItem> startingItems;
        [SerializeField] private List<EquippableItem> characterItems;
        [SerializeField] private PlayerEquipmentController _equipmentController;


        [SerializeField] private Transform itemParent;

        public event Action<BaseItemSlot> OnPointerEnterEvent;
        public event Action<BaseItemSlot> OnPointerExitEvent;
        public event Action<BaseItemSlot> OnBeginDragEvent;
        public event Action<BaseItemSlot> OnEndDragEvent;
        public event Action<BaseItemSlot> OnDragEvent;
        public event Action<BaseItemSlot> OnDropEvent;
        public event Action<BaseItemSlot> OnShiftRightClickEvent;
        public event Action<BaseItemSlot> onBuyEvent;

        public Action<EquippableItem> OnCharInvEquip; //todo implement this
        public Action<EquippableItem> OnCharInvUnequip; //todo implement this

        private void OnEnable()
        {
            OnCharInvEquip += SetItems;
        }


        private void SetItems(EquippableItem item)
        {
            _equipmentController.EquipItem(SlotCategory.Armor,item.part); //add converter for equipment type to slot category
            foreach (var slot in (EquipmentSlot[])itemSlots)
            {
                if (slot.equipmentType == item.equipmentType)
                {
                    slot.Item = item;
                    break;
                }
            }
        }
        
        public void EquipAllItems(List<EquippableItem> playerDataEquipment)
        {
            foreach (var equippable in playerDataEquipment)
            {
                SetItems(equippable);
            }
        }

        private void OnDisable()
        {
            OnCharInvEquip -= SetItems;
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