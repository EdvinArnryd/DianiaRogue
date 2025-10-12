using UnityEngine;

public class FirePoolProjectile : Projectile
{
    private void Start()
    {
        _isPierce = true;
    }
    protected override void Move()
    {
        transform.Rotate(0,0,90 * Time.deltaTime);
    }
}
