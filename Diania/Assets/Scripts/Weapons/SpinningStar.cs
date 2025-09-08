using UnityEngine;

public class SpinningStar : Weapon
{
    public Transform player;
    public float rotationSpeed = 200f;
    public float orbitRadius = 2f;

    private float angle;

    void Update()
    {
        if (player == null) return;

        angle += rotationSpeed * Time.deltaTime;

        // Compute position relative to player
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;

        transform.position = player.position + offset;
    }
}