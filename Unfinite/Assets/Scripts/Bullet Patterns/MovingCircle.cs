using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCircle : MonoBehaviour
{
    private List<GameObject> activeBullets;
    public void movingCircle(GameObject boss, GameObject bulletPrefab, int quantity, float distance, float speed, float direction, float rotationSpeed){
        activeBullets = new List<GameObject>();
        for(int i = 0; i < quantity; i++){
            // generate bullets around a circle at a distance away from the origin
            activeBullets.Add(Instantiate(bulletPrefab, boss.transform.position + new Vector3(distance*Mathf.Cos(i*2*Mathf.PI/quantity), distance*Mathf.Sin(i*2*Mathf.PI/quantity), 0), new Quaternion(0,0,0,0), boss.transform));
        }
        this.gameObject.GetComponent<vectorMove>().addVelocity(speed, direction);
        this.gameObject.GetComponent<laserRotate>().setRotationRadians(Mathf.PI/12.0f);
        this.gameObject.GetComponent<laserRotate>().turnSpeed = speed;
    }
    public void setSpeed(float speed){
        this.gameObject.GetComponent<vectorMove>().addVelocity(speed, this.gameObject.GetComponent<vectorMove>().getDirection());
    }
    public void setDirection(float direction){
        this.gameObject.GetComponent<vectorMove>().addVelocity(this.gameObject.GetComponent<vectorMove>().getVelocity(), direction);
    }
    public void setVector(float speed, float direction){
        this.gameObject.GetComponent<vectorMove>().addVelocity(speed, direction);
    }
    public void enableRotation(){
        this.gameObject.GetComponent<laserRotate>().enableFreeRotate(true);
    }
    public void enableRotation(bool direction, float speed){
        this.gameObject.GetComponent<laserRotate>().setRotationRadians(Mathf.PI/12.0f);
        this.gameObject.GetComponent<laserRotate>().turnSpeed = speed;
        this.gameObject.GetComponent<laserRotate>().enableFreeRotate(direction);
    }
    public void stopRotation(){
        this.gameObject.GetComponent<laserRotate>().stopRotating();
    }
    public void despawn(){
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
