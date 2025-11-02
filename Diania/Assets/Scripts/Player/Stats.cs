using UnityEngine;


public class Stats : MonoBehaviour
{
    [Header("Utility modifiers")]
    [SerializeField] float _movementSpeed;
    [SerializeField] float _experienceGain;

    [Header("Defense modifiers")]
    [SerializeField] float _health;
    [SerializeField] float _armor;
    [SerializeField] float _healthRegen;
    [SerializeField] float _lifeSteal;

    [Header("Offense modifiers")]
    [SerializeField] float _attackDamage;
    [SerializeField] float _critChance;
    [SerializeField] float _coolDownReduction;
    [SerializeField] float _size;

    private void Start()
    {
        
    }
}
