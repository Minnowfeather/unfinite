using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserRotate : MonoBehaviour
{
    private float targetDirection;
    private float currentDirection;
    private float setDirection;

    //This is the speed at which the lazer will rotate
    public float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        setDirection = currentDirection = targetDirection = 0;
    }

    // == TO DO ==
    // - Test the Radian methods

    //The addRotation methods change the target rotation by the set ammount
    //positive for anti-clockwise negative for clockwise
    public void addRotationRadians(float rotation){
        setDirection += Mathf.Rad2Deg * rotation; 
        targetDirection += Mathf.Rad2Deg * rotation; 
    }
    public void addRotationDegrees(float rotation)
    {
        setDirection += rotation; 
        targetDirection += rotation; 
    }

    //The setRotation methods directly set the angle the lazer should rotate to
    //and will take the shortest path to allign
    //rotation should be between 0 and 360 degrees (0 to 2PI radians)
    public void setRotationRadians(float rotation)
    {
        setRotationDegrees(Mathf.Rad2Deg * rotation);
    }

    public void setRotationDegrees(float rotation)
    {
        setDirection = rotation;

        if (Mathf.Abs(setDirection - (currentDirection % 360)) < 180)
        {
            targetDirection += setDirection - (targetDirection % 360);
        } else
        {
            targetDirection += setDirection + 360 - (targetDirection % 360);
        }
    }

    // Update is called once per frame
    void Update()
    {
        setDirection = setDirection % 360;

        if (setDirection < 0)
        {
            setDirection += 360;
        }

        if (Mathf.Abs(currentDirection - targetDirection) > turnSpeed)
        {
            int turnDir = (targetDirection > currentDirection) ? +1 : -1;
            
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(transform.rotation.eulerAngles.x,
                                                                                           transform.rotation.eulerAngles.y,
                                                                                           turnDir * turnSpeed));
            currentDirection += turnDir * turnSpeed;
        }
    }
}
