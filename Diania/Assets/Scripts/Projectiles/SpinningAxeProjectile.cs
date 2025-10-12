using UnityEngine;

public class SpinningAxeProjectile : Projectile
{
    private void Start()
    {
        // Face movement direction immediately
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _isPierce = false;
    }
    protected override void Move()
    {
        transform.Rotate(0,0,45 * Time.deltaTime);

        Vector2 move = _direction.normalized * _speed  * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
