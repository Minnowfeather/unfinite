using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class generatePatterns : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject laserPrefab;
    private float dT = 0; 
    private GameObject bulletBoss;

    // cone specific
    private bool cone_active = false;
    private float cone_Interval, cone_Speed, cone_Offset, cone_rotationSpeed, cone_spread;
    private int cone_Amount;
    private int cone_Count = 0;
    private float cone_Angle = 0.0f;
    private bool cone_Up = true;

    // laser specific
    private bool laser_active = false;
    private int laser_quantity;
    private float laser_spawnTime, laser_rotationSpeed, laser_offset, laser_duration;
    private List<GameObject> activeLasers;

    // pool stuf
    private List<GameObject> pool;
    private bool poolGenerated = false;

    void Start()
    {
        pool = new List<GameObject>();
        activeLasers = new List<GameObject>();
    }
    void Update()
    {
        if(cone_active){
            // LUKAS: PLEASE HELP ME OH GOD WHAT IS THIS
            while(!poolGenerated && cone_Amount != 0){
                pool.Add(Instantiate(bulletPrefab, bulletBoss.transform.position, new Quaternion(0,0,0,0), bulletBoss.transform));
                cone_Count++;
                if(cone_Count >= cone_Amount){
                    poolGenerated = true;
                    cone_Count = 0;;
                }
            }
            dT += Time.deltaTime;
            if(dT >= (cone_Interval/1000.0f)){
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
                    pool.Add(Instantiate(bulletPrefab, bulletBoss.transform.position, new Quaternion(0,0,0,0), bulletBoss.transform));
                }
                print(cone_Offset);
                pool[0].GetComponent<vectorMove>().addVelocity(cone_Speed, cone_Angle + cone_Offset);
                pool.RemoveAt(0);
                if(cone_Amount != 0){
                    cone_Count++;
                }
                dT = dT - cone_Interval/1000.0f;
            }
            if(cone_Count >= cone_Amount && cone_Amount != 0){
                cone_Count = 0;
                cone_active = false;
                poolGenerated = false;
            }
        }
        // if(laser){
            
        // }
        
    }

    /*

        Circle

        @param boss
            The boss that the bullets attach themselves to.
            Bullets spawn on the boss and extend outwards.

        @param quantity
            The amount of bullets to be made.
            Bullets are distributed evenly around a circle.

        @param speed
            The speed of the bullets.

        @param aR
            The angle at which the laser starts.
            Default (0) is an angle of 0 degrees pointing straight right.

    */
    public void circle(GameObject boss, int quantity, float speed)
    {
        float dR = (2*Mathf.PI) / quantity;
        for(int i = 0; i < quantity; i++){
            GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            temp.GetComponent<vectorMove>().addVelocity(speed, i*dR);
        }
    }
    public void circle(GameObject boss, int quantity, float speed, float offset)
    {
        float dR = (2*Mathf.PI) / quantity;
        for(int i = 0; i < quantity; i++){
            GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            temp.GetComponent<vectorMove>().addVelocity(speed, (i*dR)+offset);
        }
    }

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
    public void cone(GameObject boss, int quantity, float interval, float speed, float offset, float rotationSpeed, float spread){
        cone_active = true;
        bulletBoss = boss;
        cone_Amount = quantity;
        cone_Interval = interval;
        cone_Speed = speed;
        cone_Offset = offset;
        cone_rotationSpeed = rotationSpeed;
        cone_spread = spread;
        // maximum pi/12 radians up pi/12 down
    }
    public void startCone(GameObject boss, float interval, float speed, float offset, float rotationSpeed, float spread){
        if(!cone_active){
            cone_active = true;
            bulletBoss = boss;
            cone_Amount = 0;
            cone_Interval = interval;
            cone_Speed = speed;
            cone_Offset = offset;
            cone_rotationSpeed = rotationSpeed;
            cone_spread = spread;
        }
        // maximum pi/12 radians up pi/12 down
    }
    public void stopCone(){
        if(cone_active){
            cone_active = false;
        }
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
    public void laser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length)
    {
        laser_active = true;
        bulletBoss = boss;
        laser_quantity = quantity;
        laser_spawnTime = spawnTime;
        laser_rotationSpeed = rotationSpeed;
        laser_offset = offset;
        float dR = (2*Mathf.PI) / laser_quantity;
        for(int i = 0; i < laser_quantity; i++){
            GameObject temp = Instantiate(laserPrefab, bulletBoss.transform.position, new Quaternion(0,0,0,0), bulletBoss.transform);
            temp.transform.localScale = new Vector3(length, 1, 1);
            temp.GetComponent<laserRotate>().setRotationRadians(1);
            temp.GetComponent<laserRotate>().turnSpeed = laser_rotationSpeed*Mathf.Rad2Deg;
            temp.GetComponent<laserRotate>().enableFreeRotate(true);
        }
    }
    public void startLaser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length)
    {
        if(!laser_active){
            laser_active = true;
            bulletBoss = boss;
            laser_quantity = quantity;
            laser_spawnTime = spawnTime;
            laser_rotationSpeed = rotationSpeed;
            laser_offset = offset;
            float dR = (2*Mathf.PI) / laser_quantity;
            for(int i = 0; i < laser_quantity; i++){
                GameObject temp = Instantiate(laserPrefab, bulletBoss.transform.position, new Quaternion(0,0,0, 0), bulletBoss.transform);
                temp.transform.localScale = new Vector3(length, 1, 1);
                temp.transform.Rotate(0, 0, ((i*dR)+laser_offset) * Mathf.Rad2Deg);
                temp.GetComponent<laserRotate>().setRotationRadians(1);
                temp.GetComponent<laserRotate>().turnSpeed = laser_rotationSpeed*Mathf.Rad2Deg;
                temp.GetComponent<laserRotate>().enableFreeRotate(true);
                activeLasers.Add(temp);
            }
        }
    }
    public void stopLaser()
    {
        if(laser_active){
            laser_active = false;
            for(int i = 0; i < laser_quantity; i++){
                Destroy(activeLasers[i]);
            }
            activeLasers = new List<GameObject>();
        }
    }
    public void pauseLaser()
    {
        if(laser_active){
            for(int i = 0; i < laser_quantity; i++){
                activeLasers[i].GetComponent<laserRotate>().stopRotating();
            }
        }
    }
    public void resumeLaser()
    {
        if(laser_active){
            for(int i = 0; i < laser_quantity; i++){
                activeLasers[i].GetComponent<laserRotate>().enableFreeRotate(true);
            }
        }
    }
    public void setLaserOffset(float offset){
        laser_offset = offset;
    }
    public void setLaserRotationSpeed(float rotationSpeed){
        laser_rotationSpeed = rotationSpeed;
        for(int i = 0; i < laser_quantity; i++){
            activeLasers[i].GetComponent<laserRotate>().turnSpeed = laser_rotationSpeed*Mathf.Rad2Deg;
        }
    }


}
