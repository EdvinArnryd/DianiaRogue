using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LootManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private LootTable _lootTable;

    public event Action<Item> ItemResult;
    
    private Item _lootItem;

    void OnEnable()
    {
        _lootItem = _lootTable.ItemResult();
        
        ItemResult?.Invoke(_lootItem);

        _itemName.text = _lootItem._itemData.Name;
        _itemDescription.text = _lootItem._itemData.Description;
        _itemIcon.sprite = _lootItem._itemData.Icon;
    }

}
