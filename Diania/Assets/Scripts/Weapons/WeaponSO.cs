using UnityEngine;


// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapons", order = 1)]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _size;
    [SerializeField] private float _cooldown;

    public float ProjectileSpeed => _projectileSpeed;
    public float Damage => _damage;
    public float Size => _size;
    public float Cooldown => _cooldown;
}