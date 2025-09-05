using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float _speed = 1f;

    private Player _player;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            direction += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            direction += Vector3.down;
        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        if (direction != Vector3.zero) // prevent NaN when normalizing zero vector
        {
            direction.Normalize(); // makes diagonal magnitude = 1
            transform.position += direction * _speed * Time.deltaTime;
        }
    }
}
