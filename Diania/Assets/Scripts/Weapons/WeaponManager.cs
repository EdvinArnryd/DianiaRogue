using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// WeaponManager is currently using prefabs as weapons, which is bad practice since we don't need prefabs
// We should use ScriptableObjects instead so that each weapon becomes a component on the player(or wherever)
// This means a restructure of the weapons as a whole though.
public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> _allWeapons;
    [SerializeField] private int _inventorySize = 4;
    
    private List<Weapon> _weaponsInventory = new List<Weapon>();

    private void Start()
    {
        AddRandomWeapon();
    }

    private void AddWeapon(Weapon weapon)
    {
        if(_weaponsInventory.Count < _inventorySize)
            _weaponsInventory.Add(weapon);
        Instantiate(weapon, transform);
    }

    private void AddRandomWeapon()
    {
        int random = Random.Range(0, _allWeapons.Count);
        AddWeapon(_allWeapons[random]);
    }

}
