using System;
using Unity.VisualScripting;
using UnityEngine;

public class XPPickup : MonoBehaviour
{
    [SerializeField] private float _xpAmount = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            LevelSystem player = other.gameObject.GetComponent<LevelSystem>();
            
            player.GainExp(_xpAmount);
            
            Destroy(gameObject);
        }
    }
}
