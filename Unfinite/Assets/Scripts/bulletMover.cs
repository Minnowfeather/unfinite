using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMover : MonoBehaviour
{
    public Rigidbody2D bullet; // The prefab of the bullet
    public Vector3 input_position; // The position of the player when the bullet is fired
    public float speed = 10f;

    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();                                                   // Grabs the 2D Rigidbody component
        Vector3 vec = -(input_position - Camera.main.ScreenToWorldPoint(Input.mousePosition));  // Creates a vector that goes from the player's position to the mouse's position
        vec.z = 0;              // sets the z value of that vector to be zero (we are in 2d here hehe)
        vec = vec.normalized * speed;
        bullet.velocity = vec;  // sets the bullets velocity equal to that vector (bullet go WEEEEE)     
    }
}