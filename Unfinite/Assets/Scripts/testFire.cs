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
    public bool circle, cone, laser, bulletLine, aim, spinningCircle = false;
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
            if(aim){
                p.fireBullet(g, speed, dR);
            }
            if(spinningCircle){
                p.spinningCircle(g, amount, 1000.0f, 12.5f);
            }
        }
        if(Input.GetKeyDown("[3]")){
            p.stopCone(0);
            if(laser){
                p.stopLaser(0);
            }
        }
        if(Input.GetKeyDown("[2]")){
            p.pauseLaser(0);
            p.stopSpinningCircle(0);
        }
        if(Input.GetKeyDown("[5]")){
            p.resumeLaser(0);
            p.startSpinningCircle(0,rotationSpeed);
        }
        // p.setConeOffset(0, dR);
        // p.setConeInterval(0, interval);
        // p.setConeSpeed(0, speed);
        // p.setConeRotationSpeed(0, rotationSpeed);
        // p.setConeSpread(0, spread);
        // p.setLaserOffset(0, dR);
        // p.setLaserRotationSpeed(0, rotationSpeed);
    }
}
