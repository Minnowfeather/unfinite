using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTimeOut : MonoBehaviour
{
    //This float represents how long the bullet will exist
    //If we decide to object pool bullets this script will need to be removed
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
