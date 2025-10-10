using System;
using System.Collections.Generic;
using UnityEngine;

public class MysticAura : Weapon
{
    private float _lastAttack;
    private HashSet<Enemy> _enemiesInRange = new HashSet<Enemy>();
    void Start()
    {
        transform.position = PlayerTransform.position;
    }
    void Update()
    {
        transform.Rotate(0,0,10 * Time.deltaTime);
        
        if (Time.time - _lastAttack >= Cooldown)
        {
            DealDamage();
            _lastAttack = Time.time;
        }
    }

    // This function needs update in the future.
    // List of enemies will grow forever if not taken care of.
    private void DealDamage()
    {
        foreach (var enemy in _enemiesInRange)
        {
            if (!enemy) return;
            enemy.TakeDamage(Damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (!enemy) return;
            _enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (!enemy) return;
        _enemiesInRange.Remove(enemy);
    }
}
