using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private WeaponManager _weaponManager;
    
    public Weapon _weapon;

    public void InitializeButtonData()
    {
        _icon.sprite = _weapon.WeaponData.Icon;
        _name.text = _weapon.WeaponData.Name;
    }

    public void OnButtonPress()
    {
        _weaponManager.AddWeapon(_weapon);
    }
    
    
    
}
