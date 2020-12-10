using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLine : MonoBehaviour
{
    /* Bullet Line

    */
    private bool bulletLine_active = false;
    private int bulletLine_lineQuantity, bulletLine_bulletQuantity;
    private float bulletLine_spacing, bulletLine_spawnTime, bulletLine_offset;
    private GameObject bulletLinePivotPoint, spinningCirclePivotPoint;
    private List<List<GameObject>> bulletLine_pool;
    public GameObject bulletLinePrefab;
    private float bulletLine_dT = 0; 

    public void bulletLine(GameObject boss, GameObject bulletPrefab, int quantityLines, int quantityBullets, float spacing, float spawnTime, float offset)
    {
        bulletLine_pool = new List<List<GameObject>>();
        bulletLine_active = true;
        bulletLine_lineQuantity = quantityLines;
        bulletLine_bulletQuantity = quantityBullets;
        bulletLine_spacing = spacing;
        bulletLine_spawnTime = spawnTime;
        bulletLine_offset = offset;

        // create pivot point
        bulletLinePivotPoint = Instantiate(bulletLinePrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        // generate bullet lines
        for(int i = 0; i < bulletLine_lineQuantity; i++){
            // make new line of bullets
            bulletLine_pool.Add(new List<GameObject>());
            for(int j = 0; j < bulletLine_bulletQuantity; j++){
                //populate new line with bullets
                bulletLine_pool[i].Add(Instantiate(bulletPrefab, bulletLinePivotPoint.transform.position, new Quaternion(0,0,0,0), bulletLinePivotPoint.transform));
                // start moving the bullet outward (spawn animation)
                bulletLine_pool[i][j].GetComponent<vectorMove>().addVelocity(bulletLine_spacing/(bulletLine_spawnTime/1000.0f), bulletLine_offset + (i*2*Mathf.PI)/bulletLine_lineQuantity);
            }
        }
    }
    public void startBulletLineRotation(float rotationSpeed){
        bulletLinePivotPoint.GetComponent<laserRotate>().setRotationRadians(rotationSpeed);
        bulletLinePivotPoint.GetComponent<laserRotate>().enableFreeRotate(true);
    }
    public void stopBulletLineRotation(){
        bulletLinePivotPoint.GetComponent<laserRotate>().stopRotating();
    }
    public void despawn(){
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletLine_active){
            // keep track of time
            bulletLine_dT += Time.deltaTime;
            for(int i = 0; i < bulletLine_pool.Count; i++){
                for(int j = 0; j < bulletLine_pool[i].Count; j++){
                    // when the bullet has reached its destination, freeze it in place
                    if((Vector3.Distance(bulletLine_pool[i][j].transform.position, bulletLinePivotPoint.transform.position) >= (bulletLine_spacing*(j+1)))){
                        bulletLine_pool[i][j].GetComponent<vectorMove>().addVelocity(0, 0);
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
    }
}
