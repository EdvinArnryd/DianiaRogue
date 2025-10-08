using UnityEngine;

public class MagicSquare : Weapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,10 * Time.deltaTime);
    }
}