using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
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
    }
}
