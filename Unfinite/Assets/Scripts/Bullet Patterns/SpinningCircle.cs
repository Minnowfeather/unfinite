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
        spinningCirclePivotPoint = Instantiate(spinningCirclePrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        print(spinningCirclePivotPoint);
        spinningCircle_active = true;
        spinningCircle_quantity = quantity;
        spinningCircle_spawnTime = spawnTime;
        spinningCircle_distance = distance;
        for(int i = 0; i < quantity; i++){
            spinningCircle_pool.Add(Instantiate(bulletPrefab, spinningCirclePivotPoint.transform.position, new Quaternion(0,0,0,0), spinningCirclePivotPoint.transform));
            print("not ya boi");
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
    // Start is called before the first frame update
    void Start()
    {
        spinningCircle_pool = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spinningCircle_active){
            for(int i = 0; i < spinningCircle_pool.Count; i++){
                if(Vector3.Distance(spinningCircle_pool[i].transform.position, spinningCirclePivotPoint.transform.position) >= spinningCircle_distance){
                    spinningCircle_pool[i].GetComponent<vectorMove>().addVelocity(0,0);
                }
            }
        }
    }
}
