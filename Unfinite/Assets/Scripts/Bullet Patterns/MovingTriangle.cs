using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTriangle : MonoBehaviour
{

    public List<GameObject> activeBullets;
    
    public void movingTriangle(GameObject bulletPrefab, int quantity, float width, float height, float speed, float direction)
    {
        activeBullets = new List<GameObject>();
        
        Vector3 pos = new Vector3(0, 0, 0);
        print("one");
        for(int i = 0 ; i < quantity; i++){
            pos = new Vector3((-width/2.0f) + i*width/quantity, -height/2.0f, 0);
            activeBullets.Add(Instantiate(bulletPrefab, pos, new Quaternion(0,0,0,0), this.gameObject.transform));
        }
        print("two");
        for(int i = 1; i < quantity; i++){
            pos = new Vector3((-width/2.0f) + i*width/(2.0f*quantity), (-height/2.0f) + i*height/quantity, 0); 
            activeBullets.Add(Instantiate(bulletPrefab, pos, new Quaternion(0,0,0,0), this.gameObject.transform));
        }
        print("three");
        for(int i = 0; i < quantity; i++){
            pos = new Vector3(i*width/(2.0f*quantity), (height/2.0f) - i*height/quantity, 0); 
            activeBullets.Add(Instantiate(bulletPrefab, pos, new Quaternion(0,0,0,0), this.gameObject.transform));
        }
        print("done"); 
        this.gameObject.GetComponent<vectorMove>().addVelocity(speed, direction);
        // this.gameObject.GetComponent<laserRotate>().setRotationRadians()
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
