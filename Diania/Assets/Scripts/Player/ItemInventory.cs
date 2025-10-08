using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] private LootManager _lootResult;
    [SerializeField] private GameObject _itemUIPrefab;
    [SerializeField] private Transform _inventorySlot;
    
    private List<Item> _inventory;

    private void Awake()
    {
        _inventory = new List<Item>();
        _lootResult.ItemResult += AddItemToInventoryHandler;
    }

    private void OnDestroy()
    {
        _lootResult.ItemResult -= AddItemToInventoryHandler;
    }

    private void AddItemToInventoryHandler(Item item)
    {
        _inventory.Add(item);
        CreateItemUI(item);
    }

    private void CreateItemUI(Item item)
    {
        // Instantiate the UI prefab
        GameObject itemUI = Instantiate(_itemUIPrefab, _inventorySlot);

        InventoryItemUI itemUIComponent = itemUI.GetComponent<InventoryItemUI>();
        itemUIComponent._itemPrefab = item;

        // Get the Image component inside the prefab
        Image iconImage = itemUI.GetComponent<Image>();

        if (iconImage != null)
            iconImage.sprite = item._itemData.Icon;
    }
}
