using UnityEngine;

public class SpinningStar : Weapon
{
    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position,new Vector2(0, 500), 2f);
        
        transform.RotateAround(PlayerTransform.position, new Vector3(0,0,1), 200f * Time.deltaTime);
        // transform.Rotate(new Vector3(0,0,1), 200f * Time.deltaTime);
    }
}
