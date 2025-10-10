using UnityEngine;

public class SpinningStar : Weapon
{
    public float rotationSpeed = 200f;
    public float orbitRadius = 2f;
    private float angle;

    void Update()
    {
        angle += ProjectileSpeed * rotationSpeed * Time.deltaTime;

        // Compute position relative to player
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;

        transform.position = PlayerTransform.position + offset;
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }
}