using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private String name;

    private float xp = 0;
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
}
