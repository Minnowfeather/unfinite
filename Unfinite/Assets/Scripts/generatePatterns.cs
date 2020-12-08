using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class generatePatterns : MonoBehaviour
{

    public GameObject bulletPrefab, laserPrefab, bulletLinePrefab, spinningCirclePrefab;
    private float bulletLine_dT, cone_dT = 0; 

    private GameObject boss;

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

    // bullet line specific
    private bool bulletLine_active = false;
    private int bulletLine_lineQuantity, bulletLine_bulletQuantity;
    private float bulletLine_spacing, bulletLine_spawnTime, bulletLine_offset;
    private GameObject bulletLinePivotPoint, spinningCirclePivotPoint;

    // spinning circle specific
    private bool spinningCircle_active;
    private int spinningCircle_quantity;
    private float spinningCircle_distance, spinningCircle_spawnTime;
    
    // pool stuf
    private List<GameObject> cone_pool, spinningCircle_pool;
    private List<List<GameObject>> bulletLine_pool;
    
    public GameObject measure;

    private float start = 0.0f;
    void Start()
    {
        boss = this.gameObject;
        bulletLine_pool = new List<List<GameObject>>();
        cone_pool = new List<GameObject>();
        spinningCircle_pool = new List<GameObject>();
        activeLasers = new List<GameObject>();
        print(Vector3.Distance(boss.transform.position, measure.transform.position));
    }
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
                print(cone_Offset);
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
        // if(laser){
            
        // }
        if(bulletLine_active){
            bulletLine_dT += Time.deltaTime;
            start += Time.deltaTime;
            for(int i = 0; i < bulletLine_pool.Count; i++){
                for(int j = 0; j < bulletLine_pool[i].Count; j++){
                    if((Vector3.Distance(bulletLine_pool[i][j].transform.position, bulletLinePivotPoint.transform.position) >= (bulletLine_spacing*(j+1)))){
                        bulletLine_pool[i][j].GetComponent<vectorMove>().addVelocity(0, 0);
                        if(j == bulletLine_pool[i].Count-1)
                        {
                            print(start);
                        }
                    }
                }
            }
            
            /*
                summon pivot
                summon bullets as children of pivot
                move outwards
                speed of bullet = num bullets / total time
            */
        }

        if(spinningCircle_active){
            for(int i = 0; i < spinningCircle_pool.Count; i++){
                if(Vector3.Distance(spinningCircle_pool[i].transform.position, spinningCirclePivotPoint.transform.position) >= spinningCircle_distance){
                    spinningCircle_pool[i].GetComponent<vectorMove>().addVelocity(0,0);
                }
            }
        }
        
    }

    /*

        Fire Bullet

        @param boss
            The boss that the bullet spawns on.
            Bullet then extends outwards.
        
        @param speed
            How fast the bullet should move.
            Measured in distance per frame
        
        @param direction
            The angle at which the bullet should fire.
            Measured in radians.

        @param target
            The target at which the boss should fire at.
            This is the position of the target.
        
        
    */
    public void fireBullet(GameObject boss, float speed, float direction){
        GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        temp.GetComponent<vectorMove>().addVelocity(speed, direction);
    }
    public void fireBullet(GameObject boss, float speed, Vector3 target){
        GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        temp.GetComponent<vectorMove>().addVelocity(speed, Vector3.Angle(boss.transform.position, target) * Mathf.Deg2Rad);
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

        Spinning Circle

    */
    public void spinningCircle(GameObject boss, int quantity, float spawnTime, float distance)
    {
        spinningCirclePivotPoint = Instantiate(spinningCirclePrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        spinningCircle_active = true;
        spinningCircle_quantity = quantity;
        spinningCircle_spawnTime = spawnTime;
        spinningCircle_distance = distance;
        for(int i = 0; i < quantity; i++){
            spinningCircle_pool.Add(Instantiate(bulletPrefab, spinningCirclePivotPoint.transform.position, new Quaternion(0,0,0,0), spinningCirclePivotPoint.transform));
            spinningCircle_pool[i].GetComponent<vectorMove>().addVelocity(distance/(10000.0f/spinningCircle_spawnTime), (i*2*Mathf.PI)/spinningCircle_quantity, 1000/(10000.0f/spinningCircle_spawnTime));
        }
    }
    public void startSpinningCircle(float rotationSpeed)
    {
        spinningCirclePivotPoint.GetComponent<laserRotate>().setRotationRadians(rotationSpeed);
        spinningCirclePivotPoint.GetComponent<laserRotate>().enableFreeRotate(true);
    }
    public void stopSpinningCircle(){
        spinningCirclePivotPoint.GetComponent<laserRotate>().stopRotating();
    }


    /*

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
        cone_Amount = quantity;
        cone_Interval = interval;
        cone_Speed = speed;
        cone_Offset = offset;
        cone_rotationSpeed = rotationSpeed;
        cone_spread = spread;

        for(int i = 0; i < cone_Amount; i++){
            cone_pool.Add(Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        }
        // maximum pi/12 radians up pi/12 down
    }
    public void startCone(GameObject boss, float interval, float speed, float offset, float rotationSpeed, float spread){
        if(!cone_active){
            cone_active = true;
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

    /* Bullet Line

    */
    public void bulletLine(GameObject boss, int quantityLines, int quantityBullets, float spacing, float spawnTime, float offset)
    {
        bulletLine_active = true;
        bulletLine_lineQuantity = quantityLines;
        bulletLine_bulletQuantity = quantityBullets;
        bulletLine_spacing = spacing;
        bulletLine_spawnTime = spawnTime;
        bulletLine_offset = offset;

        bulletLinePivotPoint = Instantiate(bulletLinePrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        for(int i = 0; i < bulletLine_lineQuantity; i++){
            bulletLine_pool.Add(new List<GameObject>());
            for(int j = 0; j < bulletLine_bulletQuantity; j++){
                bulletLine_pool[i].Add(Instantiate(bulletPrefab, bulletLinePivotPoint.transform.position, new Quaternion(0,0,0,0), bulletLinePivotPoint.transform));
                bulletLine_pool[i][j].GetComponent<vectorMove>().addVelocity(bulletLine_spacing/(bulletLine_spawnTime/1000.0f), bulletLine_offset + (i*2*Mathf.PI)/bulletLine_lineQuantity);
            }
        }
    }
    public void startBulletLineRotation(float rotationSpeed){
        bulletLinePivotPoint.GetComponent<laserRotate>().setRotationRadians(rotationSpeed);
        bulletLinePivotPoint.GetComponent<laserRotate>().enableFreeRotate(true);
    }
    public void stopBulletLineRotation(float rotationSpeed){
        bulletLinePivotPoint.GetComponent<laserRotate>().stopRotating();
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
        laser_quantity = quantity;
        laser_spawnTime = spawnTime;
        laser_rotationSpeed = rotationSpeed;
        laser_offset = offset;
        float dR = (2*Mathf.PI) / laser_quantity;
        for(int i = 0; i < laser_quantity; i++){
            GameObject temp = Instantiate(laserPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
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
