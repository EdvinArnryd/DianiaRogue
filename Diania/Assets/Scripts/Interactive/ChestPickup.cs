using System;
using UnityEngine;

public class ChestPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PauseManager.Instance.OnPlayerPickupHandler();

            Destroy(gameObject);
        }
    }
}
