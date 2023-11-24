using CharacterCreator2D;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.InventorySystem
{
    public class EquipmentSlot : ItemSlot
    {
        public EquipmentType equipmentType;
        [SerializeField] Color emptyColor = Color.gray;
        [SerializeField] private PlayerEquipmentController equipmentController;
        [SerializeField] private CharacterInventory characterInventory;

        protected override void OnValidate()
        {
            if (image == null)
                image = GetComponentInChildren<Image>();
        }

        public override bool CanAddStack(Item item, int amount = 1) => false;

        public override bool CanReceiveItem(Item item)
        {
            if (item is EquippableItem && ((EquippableItem)item).equipmentType == equipmentType ||
                item == null) //Todo level check
            {
                if (item != null) EquipItem(item);
                else
                {
                    UnEquipItem(item);
                }

                return true;
            }

            return false;
        }

        private void UnEquipItem(Item item)
        {
            equipmentController.onEquipmentChanged.Invoke(SlotCategory.Armor, null);
            
            //characterInventory.OnCharInvUnequip.Invoke((EquippableItem)item);
        }

        private void EquipItem(Item item)
        {
            equipmentController.onEquipmentChanged.Invoke(SlotCategory.Armor, ((EquippableItem)item).part);
            characterInventory.OnCharInvEquip.Invoke((EquippableItem)item);
        }

        //equip all items
        public void EquipAllItems(EquippableItem[] equippableItems)
        {
            foreach (var item in equippableItems)
            {
                equipmentController.onEquipmentChanged.Invoke(SlotCategory.Armor, item.part);
            }
        }
    }
}