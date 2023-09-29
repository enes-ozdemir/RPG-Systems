using UnityEngine;

namespace _Scripts.InventorySystem.QuickSlot
{
    public class QuickSlot : ItemSlot
    {
        [SerializeField] private GameObject selection;

        private bool _isSelected;

        private void OnEnable()
        {
            OnPointerEnterEvent += SelectSlot;
            OnPointerExitEvent += DeSelectSlot;
            OnClickEvent += UseItem;
        }
        
        private void UseItem(BaseItemSlot baseItemSlot)
        {
            baseItemSlot.Item.UseItem();
            //todo implement item usage
        }

        private void OnDisable()
        {
            OnPointerEnterEvent -= SelectSlot;
            OnPointerExitEvent -= DeSelectSlot;
            OnClickEvent -= UseItem;
        }

        private void SelectSlot(BaseItemSlot slot) => selection.SetActive(true);

        private void DeSelectSlot(BaseItemSlot slot) => selection.SetActive(false);

        private void Start() => DeSelectSlot(this);

        public override bool CanAddStack(Item item, int amount = 1) => false;

        public override bool CanReceiveItem(Item item)
        {
            if (item is EquippableItem && ((EquippableItem)item).equipmentType == EquipmentType.Potion ||
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
            Debug.Log("Item UnEquipItem from quick slot");
            Item = null;
            image.gameObject.SetActive(false);
        }

        private void EquipItem(Item item)
        {
            Debug.Log("Item equiped into quick slot");
            //Todo look into this
            Item = item;
            image.gameObject.SetActive(true);
        }
    }
}