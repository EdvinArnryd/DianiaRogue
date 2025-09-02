using System;
using UnityEngine;


// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class Enemy : ScriptableObject
{
    [SerializeField] private String _name;
    [SerializeField] private float _damage;
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
}
