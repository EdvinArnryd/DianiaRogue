using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private string _name;

    private float _xp = 0;

    private bool _isAlive = true;

    private Vector2 _weaponPosition;

    [SerializeField]private float health = 100;

    private void Start()
    {
        _weaponPosition = transform.position;
    }

    public void GainExp(float amount)
    {
        _xp += amount;
        print(_xp);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public void PlayerDied()
    {
        _isAlive = false;
    }
}
