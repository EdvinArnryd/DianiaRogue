using UnityEngine;

public class MagicSquare : Weapon
{
    [SerializeField] private GameObject _projectilePrefab; // The projectile prefab to shoot

    private float _lastAttackTime;

    void Update()
    {
        // Step 1: Check if enough time has passed since the last attack
        if (Time.time - _lastAttackTime >= Cooldown)
        {
            _lastAttackTime = Time.time; // reset cooldown timer
            Shoot();
        }
    }

    private void Shoot()
    {
        // 2. Pick random direction
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        // 3. Spawn projectile
        GameObject proj = Instantiate(_projectilePrefab, PlayerTransform.position, Quaternion.identity);

        // 4. Initialize projectile
        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.Initialize(Damage, ProjectileSpeed, direction, null);
    }
}