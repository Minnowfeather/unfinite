﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningLaser : MonoBehaviour
{

    
    /*

        Laser

        @param boss
            This is the boss it spawns on.
            The lasers anchor on the boss and extend outwards
        
        @param quantity
            Number of lasers.
            Distributed evently across a circle.

        @oaram spawnTime
            The time it takes for the laser to become active (have hurtbox).

        @param rotationSpeed
            How fast the laser rotates.
            Measured in radians per frame.
            Higher values mean faster rotations

        @param offset
            The angle at which the laser starts.
            Default (0) is an angle of 0 degrees pointing straight right.

        @param length
            The length multiplier of the laser
            Final length = (base length) * (length)
            
        Functions should be self-explanatory

    */

    private int laser_quantity;
    private float laser_spawnTime, laser_rotationSpeed, laser_offset, laser_duration;
    private List<GameObject> activeLasers;
    public GameObject laserPrefab;
    
    public void laser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length)
    {
        activeLasers = new List<GameObject>();
        laser_quantity = quantity;
        laser_spawnTime = spawnTime;
        laser_rotationSpeed = rotationSpeed;
        laser_offset = offset;
        float dR = (2*Mathf.PI) / laser_quantity;
        for(int i = 0; i < laser_quantity; i++){
            // spawn a new laser
            GameObject temp = Instantiate(laserPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            // scale it up by length
            temp.transform.localScale = new Vector3(length, 1, 1);
            // rotate it to place
            temp.transform.Rotate(0, 0, ((i*dR)+laser_offset) * Mathf.Rad2Deg);
            // apply the rotation speed
            temp.GetComponent<laserRotate>().setRotationRadians(1);
            temp.GetComponent<laserRotate>().turnSpeed = laser_rotationSpeed*Mathf.Rad2Deg;
            activeLasers.Add(temp);
            // temp.GetComponent<laserRotate>().enableFreeRotate(true);
        }
    }
    public void startLaser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length)
    {
        // same idea as above
        activeLasers = new List<GameObject>();
        laser_quantity = quantity;
        laser_spawnTime = spawnTime;
        laser_rotationSpeed = rotationSpeed;
        laser_offset = offset;
        float dR = (2*Mathf.PI) / laser_quantity;
        for(int i = 0; i < laser_quantity; i++){
            GameObject temp = Instantiate(laserPrefab, boss.transform.position, new Quaternion(0,0,0, 0), boss.transform);
            temp.transform.localScale = new Vector3(length, 1, 1);
            temp.transform.Rotate(0, 0, ((i*dR)+laser_offset) * Mathf.Rad2Deg);
            temp.GetComponent<laserRotate>().setRotationRadians(1);
            temp.GetComponent<laserRotate>().turnSpeed = laser_rotationSpeed*Mathf.Rad2Deg;
            // let it rotate freely
            temp.GetComponent<laserRotate>().enableFreeRotate(true);
            activeLasers.Add(temp);
        }
    }
    // public void stop()
    // {
    //     despawn();
    // }
    public void pause()
    {
        for(int i = 0; i < laser_quantity; i++){
            activeLasers[i].GetComponent<laserRotate>().stopRotating();
        }
    }
    public void resume()
    {
        for(int i = 0; i < laser_quantity; i++){
            activeLasers[i].GetComponent<laserRotate>().enableFreeRotate(true);
        }
    }
    public void setOffset(float offset){
        laser_offset = offset;
    }
    public void setRotationSpeed(float rotationSpeed){
        laser_rotationSpeed = rotationSpeed;
        for(int i = 0; i < laser_quantity; i++){
            activeLasers[i].GetComponent<laserRotate>().turnSpeed = laser_rotationSpeed*Mathf.Rad2Deg;
        }
    }
    public void despawn(){
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
