using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Scripts;
using _Scripts.Data;
using _Scripts.InventorySystem;
using _Scripts.InventorySystem.QuickSlot;
using Enca.SaveSystem;
using UnityEngine;

public class SceneDataManager : MonoBehaviour,ISaveable
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private QuickSlotPanel quickSlotPanel;
    [SerializeField] private CharacterInventory characterInventory;
    
    public PlayerData _playerData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public async Task OnSaveAsync()
    {
        await SaveLoadUtility.SaveAsync(_playerData);
    }

    public async Task OnLoadAsync()
    {
        await SaveLoadUtility.LoadAsync(_playerData);
    }

    private void OnEnable()
    {
        quickSlotPanel.OnQuickSlotChanged += SetQuickSlotItems;
        characterInventory.OnCharInvEquip += SetCharInvItems;
        characterInventory.OnCharInvEquip += RemoveCharInvItems;
        SceneController.onNewSceneLoaded += OnNewSceneLoaded;
    }

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

    private void RemoveCharInvItems(EquippableItem item)
    {
        _playerData.equipment.Remove(item);

    }

    private void SetCharInvItems(EquippableItem item)
    {
        _playerData.equipment.Add(item);
    }

    private async void Start()
    {
        // DataManager.SetDroppedItems(InitializeDroppedItems());
        await LoadInfo();
    }

    private async Task LoadInfo()
    {
        await OnLoadAsync();
        InitQuickSlot();
    }

    private void SetQuickSlotItems(ItemSlot[] itemSlots)
    {
        var itemList = new List<Item>();
        foreach (var itemSlot in itemSlots)
        {
            itemList.Add(itemSlot.Item);
        }

        _playerData.quickSlotItems = itemList.ToArray();
    }

    private void InitQuickSlot()
    {
       // var quickSlotItems = DataManager.GetQuickSlotItems();
        quickSlotPanel.RemoveInventory();
        quickSlotPanel.OverrideQuickSlotItems(_playerData.quickSlotItems.ToArray());
        characterInventory.RemoveInventory();
        characterInventory.EquipAllItems(_playerData.equipment);
    }

}