using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTimeOut : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += 0.01f;
        if(time >= 1f){
            Destroy(gameObject);
        }
    }
}
