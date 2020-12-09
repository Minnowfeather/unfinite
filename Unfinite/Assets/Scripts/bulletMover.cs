using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMover : MonoBehaviour
{
    public Rigidbody2D clone;
    public Vector3 mouse_position;
    public Vector3 input_position;

    void Start()
    {
        clone = GetComponent<Rigidbody2D>();
        Vector3 vec = -(input_position - mouse_position);
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