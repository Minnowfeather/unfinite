using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;     // The rigidbody component of the prefab
    public float speed = 15f;  // The speed the player travels at
    public GameObject bullet;  // The prefab of the bullet (shooty shooty pew pew bang bang)
    public float shotDelay = 0.1f;
    
    void Start() // This is nothing but a comment, carry on 
    {
        rb = GetComponent<Rigidbody2D>(); // Grabs the 2D component of the Rigidbody
        StartCoroutine(Shoot());
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"), 0f); // Player movement
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetAxis("Fire1") == 1) // Deals with bullet instantiation
            {
                GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity); // Instantiates the bullet
                bulletMover mover = clone.GetComponent<bulletMover>();             // Grabs the bulletMover script 
                mover.input_position = transform.position;                                // and sets the input_position vector to be the player's vector

                yield return new WaitForSecondsRealtime(shotDelay);
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }

            Debug.Log("Loop");
        }
    }
}