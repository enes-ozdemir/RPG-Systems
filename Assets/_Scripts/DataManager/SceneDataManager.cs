using System.Linq;
using System.Threading.Tasks;
using _Scripts.InventorySystem;
using UnityEngine;

namespace _Scripts
{
    public class SceneDataManager : DataManager
    {
        [SerializeField] private InventoryManager inventoryManager;

        private void OnEnable()
        {
            inventoryManager.OnQuickSlotChanged += SetQuickSlotItems;
           // characterInventory.OnCharInvEquip += SetCharInvItems;
          //  characterInventory.OnCharInvEquip += RemoveCharInvItems;
            SceneController.onNewSceneLoaded += OnNewSceneLoaded;
        }

        private void SetQuickSlotItems(Item[] itemArray) => playerData.quickSlotItems = itemArray.ToArray();

        public override async void OnNewSceneLoaded(int obj)
        {
            //Todo make this go to loading scene ??
            base.OnNewSceneLoaded(obj);
            await LoadInfo();
        }

        private void RemoveCharInvItems(EquippableItem item) => playerData.equipment.Remove(item);

        private void SetCharInvItems(EquippableItem item) => playerData.equipment.Add(item);

        private async void Start()
        {
            await LoadInfo();
        }

        private async Task LoadInfo()
        {
            inventoryManager.InitQuickSlot(playerData.quickSlotItems.ToArray());
        }
    }
}