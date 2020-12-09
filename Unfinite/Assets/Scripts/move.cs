using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    public GameObject bullet;
    public float gravity = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"), 0f);
        if (Input.GetAxis("Fire1") == 1)
        {
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
            clone.AddComponent<Rigidbody2D>();
            (clone.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D).gravityScale = gravity;
            clone.AddComponent<bulletMover>();
            (clone.GetComponent(typeof(bulletMover)) as bulletMover).input_position = transform.position;
            (clone.GetComponent(typeof(bulletMover)) as bulletMover).mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

    }
}