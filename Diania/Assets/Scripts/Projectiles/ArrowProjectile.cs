using UnityEngine;

public class ArrowProjectile : Projectile
{
    protected override void Move()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
    
        transform.position = Vector2.MoveTowards(
            transform.position,
            _target.position,
            _speed * Time.deltaTime
        );
    }
}
