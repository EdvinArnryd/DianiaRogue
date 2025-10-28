using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 70;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _height = 2;

    private void Update()
    {
        transform.position += transform.up * Mathf.Cos(Time.time * _height) * Time.deltaTime * _speed;
    }

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
