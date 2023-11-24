using UnityEngine;

namespace _Scripts.InventorySystem.QuickSlot
{
    public class QuickSlot : ItemSlot
    {
        [SerializeField] private GameObject selection;
        [SerializeField] private QuickSlotPanel quickSlotPanel;
        private bool _isSelected;

        protected override void OnValidate()
        {
            base.OnValidate();
            quickSlotPanel = GetComponentInParent<QuickSlotPanel>();
        }

        private void OnEnable()
        {
            OnPointerEnterEvent += SelectSlot;
            OnPointerExitEvent += DeSelectSlot;
            OnClickEvent += UseItem;
        }

        private void UseItem(BaseItemSlot baseItemSlot)
        {
            // baseItemSlot.Item.UseItem();
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
                return true;
            }

            return false;
        }

        public void AddItemToSlot(Item item) => Item = item;
    }
}