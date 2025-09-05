using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private EnemySO _enemy;

    private Player _player;

    private bool _isColliding = false;
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _enemy.Speed * Time.deltaTime);

        if (_isColliding)
        {
            _player.TakeDamage(_enemy.Damage / 60);

            print(_player.GetHealth());
            if (_player.GetHealth() <= 0)
            {
                _player.PlayerDied();
                Destroy(_player.gameObject);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Collision detected");
            _isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isColliding = false;
        }
    }
}
