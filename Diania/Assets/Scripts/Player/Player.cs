using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private string _name;

    private bool _isAlive = true;

    private Vector2 _weaponPosition;

    public event Action OnPlayerDied;

    [SerializeField] private float _health = 100;

    private void Start()
    {
        _weaponPosition = transform.position;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    public float GetHealth()
    {
        return _health;
    }

    public void PlayerDied()
    {
        _isAlive = false;
        OnPlayerDied?.Invoke();
    }
}
