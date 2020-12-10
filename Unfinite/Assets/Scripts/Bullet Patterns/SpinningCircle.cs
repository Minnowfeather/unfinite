using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCircle : MonoBehaviour
{
    private bool spinningCircle_active;
    private int spinningCircle_quantity;
    private float spinningCircle_distance, spinningCircle_spawnTime;
    public GameObject spinningCirclePrefab;
    private GameObject spinningCirclePivotPoint;
    private List<GameObject> spinningCircle_pool;
    public void spinningCircle(GameObject boss, GameObject bulletPrefab, int quantity, float spawnTime, float distance)
    {
        spinningCircle_pool = new List<GameObject>();
        spinningCircle_active = true;
        spinningCircle_quantity = quantity;
        spinningCircle_spawnTime = spawnTime;
        spinningCircle_distance = distance;

        // create pivot point
        spinningCirclePivotPoint = Instantiate(spinningCirclePrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        // generate bullets in a circle
        for(int i = 0; i < quantity; i++){
            // create bullet
            spinningCircle_pool.Add(Instantiate(bulletPrefab, spinningCirclePivotPoint.transform.position, new Quaternion(0,0,0,0), spinningCirclePivotPoint.transform));
            // start moving it out towards the position
            spinningCircle_pool[i].GetComponent<vectorMove>().addVelocity(distance/(10000.0f/spinningCircle_spawnTime), (i*2*Mathf.PI)/spinningCircle_quantity, 1000/(10000.0f/spinningCircle_spawnTime));
        }
    }
    public void start(float rotationSpeed)
    {
        spinningCirclePivotPoint.GetComponent<laserRotate>().setRotationRadians(rotationSpeed);
        spinningCirclePivotPoint.GetComponent<laserRotate>().enableFreeRotate(true);
    }
    public void stop(){
        spinningCirclePivotPoint.GetComponent<laserRotate>().stopRotating();
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
        if(spinningCircle_active){
            for(int i = 0; i < spinningCircle_pool.Count; i++){
                // once the bullet reaches its position, freeze it in place
                if(Vector3.Distance(spinningCircle_pool[i].transform.position, spinningCirclePivotPoint.transform.position) >= spinningCircle_distance){
                    spinningCircle_pool[i].GetComponent<vectorMove>().addVelocity(0,0);
                }
            }
        }
    }
}
