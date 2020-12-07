using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15f;
    public GameObject temp;
    private List<GameObject> pew = new List<GameObject>();
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
        if(Input.GetAxis("Fire1") == 1)
        {   
            Instantiate(temp, new Vector3(rb.position.x, rb.position.y, 0.0f), Quaternion.identity);
        }
    }
}
