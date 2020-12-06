using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserRotate : MonoBehaviour
{
    private Rigidbody2D body;
    private float targetDirection;
    private float currentDirection;
    [SerializeField]
    private float setDirection;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        setDirection = currentDirection = targetDirection = 0;
    }

    public void addRotationRadians(float rotation){
        setDirection += Mathf.Rad2Deg * rotation; // (rotation*180.0f/Mathf.PI);
        targetDirection += Mathf.Rad2Deg * rotation; // (rotation*180.0f/Mathf.PI);
    }
    public void addRotationDegrees(float rotation)
    {
        setDirection += rotation; // (rotation*180.0f/Mathf.PI);
        targetDirection += rotation; // (rotation*180.0f/Mathf.PI);
    }

    public void setRotation(float rotation)
    {
        setDirection = rotation;        

        targetDirection += setDirection - (targetDirection % 360);
    }

    // Update is called once per frame
    void Update()
    {
        setDirection = setDirection % 360;

        if (setDirection < 0)
        {
            setDirection += 360;
        }

        if (Mathf.Abs(currentDirection - targetDirection) > 1)
        {
            int turnDir = (targetDirection > currentDirection) ? +1 : -1;
            
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(transform.rotation.eulerAngles.x,
                                                                                           transform.rotation.eulerAngles.y,
                                                                                           turnDir * turnSpeed));
            currentDirection += turnDir * turnSpeed;
        }
    }
}
