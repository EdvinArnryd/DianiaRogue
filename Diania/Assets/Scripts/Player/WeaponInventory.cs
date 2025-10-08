using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private List<Weapon> _weaponInventory;

    private void Awake()
    {
        _weaponInventory = new List<Weapon>();
    }
}
