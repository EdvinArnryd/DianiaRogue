using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Laser : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 _playerDirection;

    void Start()
    {
        _playerDirection = PlayerTransform.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _playerDirection * ProjectileSpeed * Time.deltaTime;
        //Debug.Log(transform.position);
    }
}
