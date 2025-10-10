using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventoryWeaponUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Weapon _weaponPrefab;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Show(_weaponPrefab.WeaponData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }
}
