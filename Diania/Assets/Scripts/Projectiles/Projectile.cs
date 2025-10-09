using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float _damage;
    protected float _speed;
    protected float _lifetime = 5f;

    protected Transform _target;
    protected Vector3 _direction;

    public virtual void Initialize(float damage, float speed, Vector2 direction, Transform target = null)
    {
        _damage = damage;
        _speed = speed;
        _direction = direction.normalized;
        _target = target;

        Destroy(gameObject, _lifetime);
    }
    
    public virtual void Initialize(float damage, float speed)
    {
        _damage = damage;
        _speed = speed;

        Destroy(gameObject, _lifetime);
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
                OnHitEnemy(enemy);
            }
        }
    }

    protected virtual void OnHitEnemy(Enemy enemy)
    {
        Destroy(gameObject);
    }
}