using UnityEngine;

public class CrimsonBoomerangProjectile : Projectile
{
    private float _timeStarted;
    private void Start()
    {
        // Face movement direction immediately
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //_isPierce = false;
        _timeStarted = Time.time; 
    }
    protected override void Move()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);
        
        float radius = Mathf.Pow(Time.time - _timeStarted, .5f); // grows over time
        float angle = Time.time - _timeStarted * 10f;
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
    }
}
