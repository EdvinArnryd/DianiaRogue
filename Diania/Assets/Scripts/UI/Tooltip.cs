using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public static Tooltip Instance;

    public TMP_Text _itemNameText;
    public TMP_Text _itemDescriptionText;

    private void Awake()
    {
        Instance = this;

        foreach (var graphic in GetComponentsInChildren<Graphic>(true))
        {
            graphic.raycastTarget = false;
        }
        
        Hide();
    }

    public void Show(ItemSO item)
    {
        _itemNameText.text = item.Name;
        _itemDescriptionText.text = item.Description;
        gameObject.SetActive(true);

        Vector2 mousePos = Input.mousePosition;
        transform.position = mousePos + new Vector2(10f, -10f);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
