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

        public override bool CanAddStack(Item item, int amount = 1) => false;

        public override bool CanReceiveItem(Item item)
        {
            if (item is EquippableItem && ((EquippableItem)item).equipmentType == equipmentType ||
                item == null) //Todo level check
            {
                if (item != null) EquipItem(item);
                else
                {
                    UnEquipItem();
                }

                return true;
            }

            return false;
        }

        private void UnEquipItem()
        {
            equipmentController.onEquipmentChanged.Invoke(SlotCategory.Armor, null);    
        }

        private void EquipItem(Item item)
        {
            equipmentController.onEquipmentChanged.Invoke(SlotCategory.Armor, ((EquippableItem)item).part);
        }

        protected override void OnValidate()
        {
            if (image == null)
                image = GetComponentInChildren<Image>();
        }
    }
}