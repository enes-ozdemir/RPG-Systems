using System.Linq;
using System.Threading.Tasks;
using _Scripts.InventorySystem.QuickSlot;
using UnityEngine;

namespace _Scripts
{
    public class FightDataManager : DataManager
    {
        [SerializeField] private QuickSlotPanel quickSlotPanel;
        
        private async void Start()
        {
            await LoadInfo();
        }

        private async Task LoadInfo()
        {
            quickSlotPanel.RemoveInventory();
            quickSlotPanel.OverrideQuickSlotItems(playerData.quickSlotItems.ToArray());
        }
    }
}