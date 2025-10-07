using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item _itemPrefab;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Show(_itemPrefab._itemData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }
}
