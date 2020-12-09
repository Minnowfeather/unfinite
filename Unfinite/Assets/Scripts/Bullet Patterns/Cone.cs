using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
    /*

        Cone

        @param boss
            This is the boss it spawns on.
            The bullets start on the boss and extend outwards
        
        @param quantity
            Number of bullets to be shot in total.

        @param interval
            How long (in miliseconds) it takes to spawn a bullet.

        @float speed
            The speed of the bullets.

        @param offset
            The angle at which the cone starts.
            Default (0) is an angle of 0 degrees pointing straight right.

        @param rotationSpeed
            How fast the cone rotates.
            Higher values mean slower rotations.

        @param spread
            The maximum angle up/down from the default axis that the bullets will travel in.
            
        Functions should be self-explanatory

    */

    private List<GameObject> cone_pool;
    private GameObject bulletPrefab;
    private GameObject boss;
    private bool cone_active = false;
    private float cone_Interval, cone_Speed, cone_Offset, cone_rotationSpeed, cone_spread;
    private int cone_Amount;
    private int cone_Count = 0;
    private float cone_Angle = 0.0f;
    private bool cone_Up = true;
    private float cone_dT = 0;
    public void cone(GameObject b, GameObject bP, int quantity, float interval, float speed, float offset, float rotationSpeed, float spread){
        cone_active = true;
        cone_Amount = quantity;
        cone_Interval = interval;
        cone_Speed = speed;
        cone_Offset = offset;
        cone_rotationSpeed = rotationSpeed;
        cone_spread = spread;
        boss = b;
        bulletPrefab = bP;
        for(int i = 0; i < cone_Amount; i++){
            cone_pool.Add(Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        }
        // maximum pi/12 radians up pi/12 down
    }
    public void startCone(GameObject b, GameObject bP, float interval, float speed, float offset, float rotationSpeed, float spread){
        cone_active = true;
        cone_Amount = 0;
        cone_Interval = interval;
        cone_Speed = speed;
        cone_Offset = offset;
        cone_rotationSpeed = rotationSpeed;
        cone_spread = spread;
        boss = b;
        bulletPrefab = bP;
        // maximum pi/12 radians up pi/12 down
    }
    public void stopCone(){
        cone_active = false;
    }
    public void setConeOffset(float offset){
        cone_Offset = offset;
    }
    public void setConeInterval(float interval){
        cone_Interval = interval;
    }
    public void setConeSpeed(float speed){
        cone_Speed = speed;
    }
    public void setConeRotationSpeed(float rotationSpeed){
        cone_rotationSpeed = rotationSpeed;
    }
    public void setConeSpread(float spread){
        cone_spread = spread;
    }

    // Start is called before the first frame update
    void Start()
    {
        cone_pool = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cone_active){
            cone_dT += Time.deltaTime;
            if(cone_dT >= (cone_Interval/1000.0f)){
                if(cone_Angle <= cone_spread && cone_Up){
                    cone_Angle += (cone_spread*(1/cone_rotationSpeed));
                } else {
                    cone_Up = false;
                    if(cone_Angle >= -cone_spread){
                        cone_Angle -= (cone_spread*(1/cone_rotationSpeed));
                    } else {
                        cone_Up = true;
                    }
                }
                if(cone_Amount == 0){
                    cone_pool.Add(Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
                }
                cone_pool[0].GetComponent<vectorMove>().addVelocity(cone_Speed, cone_Angle + cone_Offset);
                cone_pool.RemoveAt(0);
                if(cone_Amount != 0){
                    cone_Count++;
                }
                cone_dT = cone_dT - cone_Interval/1000.0f;
            }
            if(cone_Count >= cone_Amount && cone_Amount != 0){
                cone_Count = 0;
                cone_active = false;
            }
        }
    }
}
