using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOrbit : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public float orbitDistance, orbitSpeed;

    private void Start()
    {
    }

    private int oldCount = 0;

    private void FixedUpdate()
    {       
        int orbitCount = objects.Count;
        if (oldCount != orbitCount)
        {
            float angleBetween = 360 / orbitCount;

            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].transform.position = (new Vector2(Mathf.Cos(Mathf.Deg2Rad * i * angleBetween), Mathf.Sin(Mathf.Deg2Rad * i * angleBetween)) * orbitDistance) + (Vector2)transform.parent.position;
            }
            oldCount = orbitCount;
        }


        foreach (GameObject obj in objects)
        {
            Vector2 oldPos = obj.transform.localPosition;
            float theta = Mathf.Rad2Deg * Mathf.Atan(oldPos.y / oldPos.x);
            if (oldPos.x < 0)
            {
                theta += 180;
            }
            theta += orbitSpeed;
            Vector2 newPos = (new Vector2(Mathf.Cos(Mathf.Deg2Rad * theta), Mathf.Sin(Mathf.Deg2Rad * theta)) * orbitDistance) + (Vector2)transform.parent.position;
            obj.transform.position = newPos;
        }
    }
}
