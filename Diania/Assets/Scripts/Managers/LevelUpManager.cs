using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private LevelUpButton _button1;
    [SerializeField] private LevelUpButton _button2;
    [SerializeField] private LevelUpButton _button3;

    private List<Weapon> _allWeapons;
    private List<Weapon> _playerWeapons;


    private void OnEnable()
    {
        _allWeapons = _weaponManager.GetAllWeapons();
        _playerWeapons = _weaponManager.GetPlayerWeapons();
        
        _allWeapons.RemoveAll(allW => _playerWeapons.Any(playerW => playerW.WeaponData == allW.WeaponData));

        int random = Random.Range(0, _allWeapons.Count);
        _button1._weapon = _allWeapons[random];
        _allWeapons.RemoveAt(random);
        int random1 = Random.Range(0, _allWeapons.Count);
        _button2._weapon = _allWeapons[random1];
        _allWeapons.RemoveAt(random1);
        int random2 = Random.Range(0, _allWeapons.Count);
        _button3._weapon = _allWeapons[random2];

        _button1.InitializeButtonData();
        _button2.InitializeButtonData();
        _button3.InitializeButtonData();

        // foreach (var weapon in _allWeapons)
        // {
        //     print(weapon.WeaponData.Name);
        // }
    }


    private void SetButtonData()
    {
        
    }

    private void OnButtonPress()
    {
        
    }
}
