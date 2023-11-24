using System.Linq;
using System.Threading.Tasks;
using _Scripts.Data;
using _Scripts.InventorySystem;
using Enca.SaveSystem;
using UnityEngine;

namespace _Scripts
{
    public class SceneDataManager : MonoBehaviour, ISaveable
    {
        [SerializeField] private InventoryManager inventoryManager;

        public PlayerData playerData;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public async Task OnSaveAsync()
        {
            await SaveLoadUtility.SaveAsync(playerData);
        }

        public async Task OnLoadAsync()
        {
            await SaveLoadUtility.LoadAsync(playerData);
        }

        private void OnEnable()
        {
            inventoryManager.OnQuickSlotChanged += SetQuickSlotItems;
            //characterInventory.OnCharInvEquip += SetCharInvItems;
            // characterInventory.OnCharInvEquip += RemoveCharInvItems;
            SceneController.onNewSceneLoaded += OnNewSceneLoaded;
        }

        private void SetQuickSlotItems(Item[] itemArray) => playerData.quickSlotItems = itemArray.ToArray();

        private async void OnDestroy()
        {
            await OnSaveAsync();
        }

        private async void OnNewSceneLoaded(int obj)
        {
            //Todo make this go to loading scene ??
            await OnSaveAsync();
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
            await OnLoadAsync();
            inventoryManager.InitQuickSlot(playerData.quickSlotItems.ToArray());
        }
    }
}