using UnityEngine;

public class Player : MonoBehaviour
{

    private string name;

    private float xp = 0;

    private bool isAlive = true;

    [SerializeField]private float health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainExp(float amount)
    {
        xp += amount;
        print(xp);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public void PlayerDied()
    {
        isAlive = false;
    }
}
