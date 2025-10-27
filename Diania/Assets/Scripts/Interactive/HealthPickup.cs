using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 70;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Heal the player

            Player player = other.GetComponent<Player>();

            player.AddHealth(_healthAmount);

            Destroy(this.gameObject);
        }
    }
}
