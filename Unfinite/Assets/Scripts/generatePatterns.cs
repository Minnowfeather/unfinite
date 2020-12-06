using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class generatePatterns : MonoBehaviour
{

    public GameObject prefab;

    void Start()
    {

    }
    void Update()
    {

    }
    public void circle(GameObject boss, int quantity, float speed)
    {
        float dR = (2*Mathf.PI) / quantity;
        for(int i = 0; i < quantity; i++){
            GameObject temp = Instantiate(prefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            temp.GetComponent<vectorMove>().addVelocity(speed, i*dR);
        }
    }
    public void circle(GameObject boss, int quantity, float speed, float aR)
    {
        float dR = (2*Mathf.PI) / quantity;
        for(int i = 0; i < quantity; i++){
            GameObject temp = Instantiate(prefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            temp.GetComponent<vectorMove>().addVelocity(speed, (i*dR)+aR);
        }
    }

    public void shantsStupidCone(GameObject boss, float time, float speed){
        print("peepee");
        float angle = 0.0f;
        bool up = true;
        for(int i = 0; i < time; i++){
            GameObject temp = Instantiate(prefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            if(angle < time/10 && up){
                angle++;
            } else {
                up = false;
                if(angle > -time/10){
                    angle--;
                } else {
                    up = true;
                }
            }
            temp.GetComponent<vectorMove>().addVelocity(speed, angle);
        }
        // maximum pi/12 radians up pi/12 down
        //
    }

}
