using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.InventorySystem
{
    public class EquipmentSlot : ItemSlot
    {
        public EquipmentType equipmentType;
        [SerializeField] Color emptyColor = Color.gray;

        public override bool CanAddStack(Item item, int amount = 1) => false;

        public override bool CanReceiveItem(Item item)
        {
            if (item is EquippableItem && ((EquippableItem)item).equipmentType == equipmentType || item==null) //Todo level check
            {
                return true;
            }

            return false;
        }

        protected override void OnValidate()
        {
            if (image  == null)
                image = GetComponentInChildren<Image>();
        }
    }
}