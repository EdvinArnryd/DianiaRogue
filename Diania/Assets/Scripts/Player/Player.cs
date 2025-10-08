using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string _name;

    private bool _isAlive = true;

    private Vector2 _weaponPosition;

    public event Action OnPlayerDied;

    [SerializeField] private float _health = 100;
    [SerializeField] private Slider _healthBar;

    //[SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _weaponPosition = transform.position;
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

    public void PlayerDied()
    {
        _isAlive = false;
        OnPlayerDied?.Invoke();
    }
}
