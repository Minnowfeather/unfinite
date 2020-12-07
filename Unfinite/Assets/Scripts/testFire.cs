using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFire : MonoBehaviour
{
    private generatePatterns p;
    private GameObject g;
    public int amount = 0;
    public float speed = 0.0f;
    public float dR = 0.0f;
    public float interval = 0.0f;
    public float rotationSpeed = 0.0f;
    public float spread = Mathf.PI/12.0f;
    public int prongs = 4;
    public bool circle, cone, laser, bulletLine = false;
    // Start is called before the first frame update
    void Start()
    {
        g = this.gameObject;
        p = GetComponent<generatePatterns>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("[1]")){
            if(cone){
                p.cone(g, amount, interval, speed, dR, rotationSpeed, spread);
            }
            if(circle){
                p.circle(g, amount, speed, dR);
            }
            if(laser){
                p.startLaser(g, amount, 0, rotationSpeed, dR, 3);
            }
            if(bulletLine){
                p.bulletLine(g, prongs, amount, 1f, 2000.0f, dR);
            }
        }
        if(Input.GetKeyDown("[3]")){
            p.stopCone();
            if(laser){
                p.stopLaser();
            }
        }
        if(Input.GetKeyDown("[2]")){
            p.pauseLaser();
        }
        if(Input.GetKeyDown("[5]")){
            p.resumeLaser();
        }
        p.setConeOffset(dR);
        p.setConeInterval(interval);
        p.setConeSpeed(speed);
        p.setConeRotationSpeed(rotationSpeed);
        p.setConeSpread(spread);
        p.setLaserOffset(dR);
        p.setLaserRotationSpeed(rotationSpeed);
    }
}
