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
        // Step 1: Spawn a projectile prefab in world space
        GameObject proj = Instantiate(_projectilePrefab, PlayerTransform.position, Quaternion.identity);

        // Step 2: Get the projectile script and initialize it
        Projectile projectile = proj.GetComponent<Projectile>();
        projectile.Initialize(Damage, ProjectileSpeed);
    }
}