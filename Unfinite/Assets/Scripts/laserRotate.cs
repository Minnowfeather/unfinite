using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserRotate : MonoBehaviour
{
    private Rigidbody2D body;
    private float dR; 
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void addRotation(float rotation){
        dR = (rotation*180.0f/Mathf.PI);
    }
    // Update is called once per frame
    void Update()
    {
        // transform.Rotate
    }
}
