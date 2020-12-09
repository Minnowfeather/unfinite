using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class generatePatterns : MonoBehaviour
{

    private GameObject boss;

    private List<GameObject> activeLasers, activeCones, activeBulletLines, activeSpinningCircles;
    public GameObject coneHandler, spinningCircleHandler, laserHandler, bulletLineHandler, bulletPrefab;

    private float start = 0.0f;
    void Start()
    {
        boss = this.gameObject;

        activeCones = new List<GameObject>();
        activeLasers = new List<GameObject>();
        activeBulletLines = new List<GameObject>();
    }
    void Update()
    {
        
    }

    /*

        Fire Bullet

        @param boss
            The boss that the bullet spawns on.
            Bullet then extends outwards.
        
        @param speed
            How fast the bullet should move.
            Measured in distance per frame
        
        @param direction
            The angle at which the bullet should fire.
            Measured in radians.

        @param target
            The target at which the boss should fire at.
            This is the position of the target.
        
        
    */
    public void fireBullet(GameObject boss, float speed, float direction){
        GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        temp.GetComponent<vectorMove>().addVelocity(speed, direction);
    }
    public void fireBullet(GameObject boss, float speed, Vector3 target){
        GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
        temp.GetComponent<vectorMove>().addVelocity(speed, Vector3.Angle(boss.transform.position, target) * Mathf.Deg2Rad);
    }


    /*

        Circle

        @param boss
            The boss that the bullets attach themselves to.
            Bullets spawn on the boss and extend outwards.

        @param quantity
            The amount of bullets to be made.
            Bullets are distributed evenly around a circle.

        @param speed
            The speed of the bullets.

        @param aR
            The angle at which the laser starts.
            Default (0) is an angle of 0 degrees pointing straight right.

    */
    public void circle(GameObject boss, int quantity, float speed)
    {
        float dR = (2*Mathf.PI) / quantity;
        for(int i = 0; i < quantity; i++){
            GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            temp.GetComponent<vectorMove>().addVelocity(speed, i*dR);
        }
    }
    public void circle(GameObject boss, int quantity, float speed, float offset)
    {
        float dR = (2*Mathf.PI) / quantity;
        for(int i = 0; i < quantity; i++){
            GameObject temp = Instantiate(bulletPrefab, boss.transform.position, new Quaternion(0,0,0,0), boss.transform);
            temp.GetComponent<vectorMove>().addVelocity(speed, (i*dR)+offset);
        }
    }

    /* 
        SPINNING CIRCLE
    */
    public void spinningCircle(GameObject boss, int quantity, float spawnTime, float distance)
    {
        activeSpinningCircles.Add(Instantiate(spinningCircleHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeSpinningCircles[activeSpinningCircles.Count-1].GetComponent<SpinningCircle>().spinningCircle(boss, bulletPrefab, quantity, spawnTime, distance);
    }
    public void startSpinningCircle(int index, float rotationSpeed)
    {
        activeSpinningCircles[index].GetComponent<SpinningCircle>().startSpinningCircle(rotationSpeed);
    }
    public void stopSpinningCircle(int index){
        activeSpinningCircles[index].GetComponent<SpinningCircle>().stopSpinningCircle();
    }

    /*
    BULLET LINE
    */
    public void bulletLine(GameObject boss, int quantityLines, int quantityBullets, float spacing, float spawnTime, float offset)
    {
        activeBulletLines.Add(Instantiate(bulletLineHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeBulletLines[activeCones.Count-1].GetComponent<BulletLine>().bulletLine(boss, bulletPrefab, quantityLines, quantityBullets, spacing, spawnTime, offset);
    }
    public void startBulletLineRotation(int index, float rotationSpeed){
        activeBulletLines[index].GetComponent<BulletLine>().startBulletLineRotation(rotationSpeed);
    }
    public void stopBulletLineRotation(int index){
         activeBulletLines[index].GetComponent<BulletLine>().stopBulletLineRotation();
    }


    /*
    CONE
    */
    public void cone(GameObject boss, int quantity, float interval, float speed, float offset, float rotationSpeed, float spread){
        activeCones.Add(Instantiate(coneHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeCones[activeCones.Count-1].GetComponent<Cone>().cone(boss, bulletPrefab, quantity, interval, speed, offset, rotationSpeed, spread);
    }
    public void startCone(GameObject boss, float interval, float speed, float offset, float rotationSpeed, float spread){
        activeCones.Add(Instantiate(coneHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeCones[activeCones.Count-1].GetComponent<Cone>().startCone(boss, bulletPrefab, interval, speed, offset, rotationSpeed, spread);
    }
    public void stopCone(int index){
        activeCones[index].GetComponent<Cone>().stopCone();
    }
    public void setConeOffset(int index, float offset){
        activeCones[index].GetComponent<Cone>().setConeOffset(offset);
    }
    public void setConeInterval(int index, float interval){
        activeCones[index].GetComponent<Cone>().setConeInterval(interval);
    }
    public void setConeSpeed(int index, float speed){
        activeCones[index].GetComponent<Cone>().setConeSpeed(speed);
    }
    public void setConeRotationSpeed(int index, float rotationSpeed){
        activeCones[index].GetComponent<Cone>().setConeRotationSpeed(rotationSpeed);
    }
    public void setConeSpread(int index, float spread){
        activeCones[index].GetComponent<Cone>().setConeSpread(spread);
    }


    /* 
    LASER
    */

    public void laser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length)
    {
        activeLasers.Add(Instantiate(laserHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeLasers[activeLasers.Count-1].GetComponent<SpinningLaser>().laser(boss, quantity, spawnTime, rotationSpeed, offset, length);
    }
    public void startLaser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length){
        activeLasers.Add(Instantiate(laserHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeLasers[activeLasers.Count-1].GetComponent<SpinningLaser>().startLaser(boss, quantity, spawnTime, rotationSpeed, offset, length);
    }
    public void stopLaser(int index){
        activeLasers[index].GetComponent<SpinningLaser>().stopLaser();
    }
    public void pauseLaser(int index){
        activeLasers[index].GetComponent<SpinningLaser>().pauseLaser();
    }
    public void resumeLaser(int index){
        activeLasers[index].GetComponent<SpinningLaser>().resumeLaser();
    }
    public void setLaserOffset(int index, float offset){
        activeLasers[index].GetComponent<SpinningLaser>().setLaserOffset(offset);
    }
    public void setLaserRotationSpeed(int index, float speed){
        activeLasers[index].GetComponent<SpinningLaser>().setLaserRotationSpeed(speed);
    }

}
