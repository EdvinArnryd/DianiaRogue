using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _idleSprite;
    [SerializeField] private GameObject _gif;
    [SerializeField] private PauseManager _pauseManager;

    private Player _player;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_pauseManager.IsPaused) return;
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            _playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            _playerTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(direction.sqrMagnitude < 1)
        {
            _idleSprite.GameObject().SetActive(true);
            _gif.GameObject().SetActive(false);
        }
        else
        {
            _idleSprite.GameObject().SetActive(false);
            _gif.GameObject().SetActive(true);
        }

        if (direction != Vector3.zero) // prevent NaN when normalizing zero vector
        {
            direction.Normalize(); // makes diagonal magnitude = 1
            transform.position += direction * _speed * Time.deltaTime;
        }
    }
}
