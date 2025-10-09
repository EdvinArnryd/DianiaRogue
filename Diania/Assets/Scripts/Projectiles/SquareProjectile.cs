using UnityEngine;

public class SquareProjectile : Projectile
{
    protected override void Move()
    {
        transform.Rotate(0,0,10 * Time.deltaTime);
    }
}
