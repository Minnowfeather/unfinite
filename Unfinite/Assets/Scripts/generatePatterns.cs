using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class generatePatterns : MonoBehaviour
{

    public GameObject prefab;
    private bool shant = false;
    private float dT = 0; 
    private float sInterval;
    private float sSpeed;
    private int sAmount;
    private int sCount = 0;
    private float sAngle = 0.0f;
    private bool sUp = true;
    private bool poolGenerated = false;
    private GameObject sBoss;
    private List<GameObject> pool;
    private float sOffset;

    void Start()
    {
        pool = new List<GameObject>();
    }
    void Update()
    {
        if(shant){
            // LUKAS: PLEASE HELP ME OH GOD WHAT IS THIS
            while(!poolGenerated){
                pool.Add(Instantiate(prefab, sBoss.transform.position, new Quaternion(0,0,0,0), sBoss.transform));
                if(sAmount >= sCount){
                    poolGenerated = true;
                    sAmount = 0;
                }
            }
            dT += Time.deltaTime;
            if(dT >= (sInterval/1000.0f)){
                if(sAngle <= Mathf.PI/12.0f && sUp){
                    sAngle += Mathf.PI/60.0f;
                } else {
                    sUp = false;
                    if(sAngle >= -Mathf.PI/12.0f){
                        sAngle -= Mathf.PI/60.0f;
                    } else {
                        sUp = true;
                    }
                }
                print(sAngle);
                pool[0].GetComponent<vectorMove>().addVelocity(sSpeed, sAngle + sOffset);
                pool.RemoveAt(0);
                sAmount++;
                dT = 0;
            }
            if(sCount >= sAmount){
                sCount = 0;
                shant = false;
                poolGenerated = false;
            }
        }
        
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

    public void startCone(GameObject boss, int amount, float interval, float speed, float offset){
        shant = true;
        sBoss = boss;
        sInterval = interval;
        sSpeed = speed;
        sAmount = amount;
        sOffset = offset;
        // maximum pi/12 radians up pi/12 down
        //
    }

    private void coneNext(){

    }

}
