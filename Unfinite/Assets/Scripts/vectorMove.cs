using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorMove : MonoBehaviour
{
    private float dx, dy, angle, time, dT;
    private Rigidbody2D body;
    Vector3 v;


    // Start is called before the first frame update
    void Start()
    {
        // dx = 0.0f;
        // dy = 0.0f;
        // angle = 0.0f;
        body = GetComponent<Rigidbody2D>();
        dT = 0.0f;
        // v = new Vector3(0.0f,0.0f, 0.0f);
    }

    public void addVelocity(float magnitude, float a)
    {
        dx = magnitude * Mathf.Cos(a);
        dy = magnitude * Mathf.Sin(a);
        v = new Vector3(dx,dy, 0.0f);
        angle = a;
        time = 0;
        // body.RotateAngle(a);
    }
    public void addVelocity(float magnitude, float a, float t)
    {
        dx = magnitude * Mathf.Cos(a);
        dy = magnitude * Mathf.Sin(a);
        v = new Vector3(dx,dy, 0.0f);
        angle = a;
        time = t;
        // body.RotateAngle(a);
    }
    public float getVelocity(){
        return (Mathf.Sqrt((dx*dx) + (dy*dy)));
    }

    // Update is called once per frame
    void Update()
    {
        dT += Time.deltaTime;
        if(time != 0){
            if(dT >= time/1000.0f){
                body.MovePosition(transform.position + v);
                dT = 0;
            }
        } else{
            body.MovePosition(transform.position + v);   
        }
            
    }
}
