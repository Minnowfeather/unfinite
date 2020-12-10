using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMover : MonoBehaviour
{
    public Rigidbody2D clone;
    public Vector3 input_position;

    void Start()
    {
        clone = GetComponent<Rigidbody2D>();
        Vector3 vec = -(input_position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
        vec.z = 0;
        clone.velocity = vec;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }
}