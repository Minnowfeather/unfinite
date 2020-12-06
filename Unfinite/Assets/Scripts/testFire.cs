using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFire : MonoBehaviour
{
    private generatePatterns p;
    private GameObject g;
    float c = 0;
    public int amount = 0;
    public float speed = 0.0f;
    public float dR = 0.0f;
    public float interval = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        g = this.gameObject;
        p = GetComponent<generatePatterns>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("[1]") || Input.GetKeyDown("[5]")){
            p.startCone(g, amount, interval, speed);
            c += dR;
        }
    }
}
