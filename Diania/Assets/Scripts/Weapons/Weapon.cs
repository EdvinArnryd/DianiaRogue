using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _weaponData;
    
    private float _projectileSpeed;
    private float _damage;
    private float _size;
    private float _cooldown;

    private void Start()
    {
        _projectileSpeed = _weaponData.ProjectileSpeed;
        _damage = _weaponData.Damage;
        _size = _weaponData.Size;
        _cooldown = _weaponData.Cooldown;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
        }
    }
}
