using UnityEngine;


// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _damage;
    [SerializeField] private float _health;
    [SerializeField] private float _speed;

    public string Name => _name;
    public float Damage => _damage;
    public float Health => _health;
    public float Speed => _speed;
}
