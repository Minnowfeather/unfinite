using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorMove : MonoBehaviour
{
    private float dx, dy, angle;
    private Rigidbody2D body;
    Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        // dx = 0.0f;
        // dy = 0.0f;
        // angle = 0.0f;
        body = GetComponent<Rigidbody2D>();
        // v = new Vector3(0.0f,0.0f, 0.0f);
    }

    public void addVelocity(float magnitude, float a)
    {
        dx = magnitude * Mathf.Cos(a);
        dy = magnitude * Mathf.Sin(a);
        v = new Vector3(dx,dy, 0.0f);
        angle = a;
        // body.RotateAngle(a);
    }

    // Update is called once per frame
    void Update()
    {
        body.MovePosition(transform.position + v);   
    }
}
