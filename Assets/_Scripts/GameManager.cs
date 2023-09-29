using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using _Scripts.InventorySystem;
using _Scripts.InventorySystem.QuickSlot;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private QuickSlotPanel quickSlotPanel;

    private void OnEnable()
    {
        quickSlotPanel.OnQuickSlotChanged += SetQuickSlotItems;
    }

    private void OnDisable()
    {
        quickSlotPanel.OnQuickSlotChanged -= SetQuickSlotItems;
    }

    private void Start()
    {
       // DataManager.SetDroppedItems(InitializeDroppedItems());
        InitQuickSlot();
    }

    private void SetQuickSlotItems(ItemSlot[] itemSlots)
    {
        var itemList = new List<Item>();
        foreach (var itemSlot in itemSlots)
        {
            itemList.Add(itemSlot.Item);
        }

        DataManager.SetQuickSlotItems(itemList);
    }

    private void InitQuickSlot()
    {
        var quickSlotItems = DataManager.GetQuickSlotItems();
        if(quickSlotItems==null) return;
        quickSlotPanel.RemoveInventory();
        quickSlotPanel.AddItems(quickSlotItems.ToArray());
    }

    private Item[] InitializeDroppedItems()
    {
        throw new NotImplementedException(); //todo get from save
    }

    private Item[] InitializeQuickSlots()
    {
        throw new NotImplementedException(); //todo get from save
    }
}