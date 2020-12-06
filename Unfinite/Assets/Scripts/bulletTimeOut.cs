using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTimeOut : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime;
    void Start()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

}
