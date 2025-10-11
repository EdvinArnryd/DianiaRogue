using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private GameObject _projectilePrefab; // The projectile prefab to shoot

    private float _lastAttackTime;

    // Update is called once per frame
    void Update()
    {
        // Step 1: Check if enough time has passed since the last attack
        if (Time.time - _lastAttackTime >= Cooldown)
        {
            // Step 2: Find the nearest enemy
            Enemy target = FindClosestEnemy();

            // Step 3: If there is a target, shoot at it
            if (target != null)
            {
                Shoot(target);
                _lastAttackTime = Time.time; // reset cooldown timer
            }
        }
    }
    
    private Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy closest = null;
        float shortestDistance = float.MaxValue;

        foreach (var enemy in enemies)
        {
            float dist = Vector2.Distance(PlayerTransform.position, enemy.transform.position);

            if (dist < shortestDistance)
            {
                shortestDistance = dist;
                closest = enemy;
            }
        }

        return closest;
    }
    
    // private void Shoot(Enemy target)
    // {
    //     // Step 1: Spawn a projectile prefab in world space
    //     GameObject proj = Instantiate(_projectilePrefab, PlayerTransform.position, Quaternion.identity);
    //
    //     // Step 2: Get the projectile script and initialize it
    //     Projectile projectile = proj.GetComponent<Projectile>();
    //     projectile.Initialize(Damage, ProjectileSpeed, target.transform.position, target.transform);
    // }
    
    private void Shoot(Enemy target)
    {
        // 1. Spawn the projectile
        GameObject proj = Instantiate(_projectilePrefab, PlayerTransform.position, Quaternion.identity);

        // 2. Compute a direction vector (enemy position - player position)
        Vector2 direction = (target.transform.position - PlayerTransform.position).normalized;

        // 3. Initialize the projectile with that direction
        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.Initialize(Damage, ProjectileSpeed, direction, target.transform);
    }

}
