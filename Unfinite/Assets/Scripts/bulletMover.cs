using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMover : MonoBehaviour
{
    public Rigidbody2D clone;
    public float bullet_speed_x = 10f;
    public float bullet_speed_y = 10f;

    void setX(float x)
    {
        bullet_speed_x = x;
    }

    void setY(float y)
    {
        bullet_speed_y = y;
    }
    void Start()
    {
        clone = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        clone.velocity = new Vector3(bullet_speed_x, bullet_speed_y, 0f);
    }
}
