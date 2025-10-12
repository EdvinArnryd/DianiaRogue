using UnityEngine;

public class FireWalker : Weapon
{
    [SerializeField] private GameObject _projectilePrefab; // The projectile prefab to shoot

    private float _lastAttackTime;

    void Update()
    {
        // Step 1: Check if enough time has passed since the last attack
        if (Time.time - _lastAttackTime >= Cooldown)
        {
            Shoot();
            _lastAttackTime = Time.time; // reset cooldown timer
        }
    }
    
    private void Shoot()
    {
        // 1. Spawn the projectile
        GameObject proj = Instantiate(_projectilePrefab, PlayerTransform.position, Quaternion.identity);

        // 3. Initialize the projectile with that direction
        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.Initialize(Damage, ProjectileSpeed);
    }
}
