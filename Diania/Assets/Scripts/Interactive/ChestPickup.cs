using UnityEngine;

public class ChestPickup : MonoBehaviour
{

    private PauseManager _pauseManager;

    void Start()
    {
        _pauseManager = FindObjectOfType<PauseManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            _pauseManager.ChestPickedUp();

            Destroy(gameObject);
        }
    }
}
