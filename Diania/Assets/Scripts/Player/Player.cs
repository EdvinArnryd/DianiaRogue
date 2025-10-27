using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string _name;

    private bool _isAlive = true;

    [SerializeField] private Transform _playerTransform;
    public Transform PlayerTransform => _playerTransform;
    
    public event Action OnPlayerDied;

    [SerializeField] private float _maxHealth = 100;
    private float _health;
    [SerializeField] private Slider _healthBar;

    void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if(!PauseManager.Instance.IsPaused)
        {
            _health -= damage;
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _health / 100f;
    }

    public float GetHealth()
    {
        return _health;
    }

    public void AddHealth(int amount)
    {
        _health += amount;
        if(_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
        UpdateHealthBar();
    }

    public void PlayerDied()
    {
        _isAlive = false;
        OnPlayerDied?.Invoke();
    }
}
