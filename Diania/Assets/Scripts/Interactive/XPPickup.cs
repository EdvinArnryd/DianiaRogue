using System;
using Unity.VisualScripting;
using UnityEngine;

public class XPPickup : MonoBehaviour
{
    [SerializeField] private float _xpAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Player player = other.gameObject.GetComponent<Player>();
            
            player.GainExp(_xpAmount);
            
            Destroy(gameObject);
        }
    }
}
