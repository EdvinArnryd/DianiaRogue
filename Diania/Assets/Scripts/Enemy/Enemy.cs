using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private EnemySO _enemy;
    [SerializeField] private GameObject _EXPPrefab;

    [SerializeField] private SpriteRenderer _sprite;

    private Player _player;
    private float _health;
    private float _damage;
    private float _speed;
    private string _name;

    private bool _isColliding = false;

    private const int SPEED = 1;
    void Start()
    {
        _health = _enemy.Health;
        _damage = _enemy.Damage;
        _speed = _enemy.Speed;
        _name = _enemy.Name;
        
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

        if (_isColliding)
        {
            _player.TakeDamage(_enemy.Damage / 60);

            // print(_player.GetHealth());
            if (_player.GetHealth() <= 0)
            {
                _player.PlayerDied();
                Destroy(_player.gameObject);
            }
        }


        RotateTowardsPlayer();
    }
    
    private IEnumerator HitReaction()
    {
        _speed = -SPEED;

        _sprite.color = Color.red;

        yield return new WaitForSeconds(0.3f);

        _sprite.color = Color.white;

        _speed = SPEED;
    }

    private void RotateTowardsPlayer()
    {
        if (transform.position.x > _player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isColliding = true;
        }

        // if (other.gameObject.CompareTag("Weapon"))
        // {
        //     Weapon weapon = other.gameObject.GetComponent<Weapon>();
        //     TakeDamage(weapon.Damage);
        // }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isColliding = false;
        }
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(HitReaction());
        _health -= damage;
        if (_health <= 0)
        {
            Instantiate(_EXPPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
