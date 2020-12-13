using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class generatePatterns : MonoBehaviour
{

    private GameObject boss;

    private List<GameObject> activeLasers, activeCones, activeBulletLines, activeSpinningCircles, activeMovingCircles, activeMovingTriangles;
    public GameObject coneHandler, spinningCircleHandler, laserHandler, bulletLineHandler, movingCircleHandler, movingTriangleHandler, bulletPrefab;

    void Start()
    {
        boss = this.gameObject;

        activeCones = new List<GameObject>();
        activeLasers = new List<GameObject>();
        activeBulletLines = new List<GameObject>();
        activeSpinningCircles = new List<GameObject>();
        activeMovingCircles = new List<GameObject>();
        activeMovingTriangles = new List<GameObject>();
    }
    void Update()
    {
        
    }

    public int getAmountActiveCones(){
        return activeCones.Count;
    }
    public int getAmountActiveLasers(){
        return activeLasers.Count;
    }
    public int getAmountActiveBulletLines(){
        return activeBulletLines.Count;
    }
    public int getAmountActiveSpinningCircles(){
        return activeSpinningCircles.Count;
    }
    public int getAmountActiveMovingCircles(){
        return activeMovingCircles.Count;
    }
    public int getAmountActiveMovingTriangles(){
        return activeMovingTriangles.Count;
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
        activeSpinningCircles[activeSpinningCircles.Count-1].GetComponent<SpinningCircle>().spinningCircle(activeSpinningCircles[activeSpinningCircles.Count-1], bulletPrefab, quantity, spawnTime, distance);
    }
    public void startSpinningCircle(int index, float rotationSpeed)
    {
        activeSpinningCircles[index].GetComponent<SpinningCircle>().start(rotationSpeed);
    }
    public void stopSpinningCircle(int index){
        activeSpinningCircles[index].GetComponent<SpinningCircle>().stop();
    }
    public void despawnSpinningCircle(int index){
        activeSpinningCircles[index].GetComponent<SpinningCircle>().despawn();
        activeSpinningCircles.RemoveAt(index);
    }

    /*
        MOVING CIRCLE
    */
    public void movingCircle(GameObject boss, int quantity, float distance, float speed, float direction, float rotationSpeed){
        activeMovingCircles.Add(Instantiate(movingCircleHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeMovingCircles[activeMovingCircles.Count-1].GetComponent<MovingCircle>().movingCircle(activeMovingCircles[activeMovingCircles.Count-1], bulletPrefab, quantity, distance, speed, direction, rotationSpeed);
    }
    public void setMovingCircleSpeed(int index, float speed){
        activeMovingCircles[index].GetComponent<MovingCircle>().setSpeed(speed);
    }
    public void setMovingCircleDirection(int index, float direction){
        activeMovingCircles[index].GetComponent<MovingCircle>().setDirection(direction);
    }
    public void setMovingCircleVector(int index, float speed, float direction){
        activeMovingCircles[index].GetComponent<MovingCircle>().setVector(speed, direction);
    }
    public void startMovingCircleRotation(int index){
        activeMovingCircles[index].GetComponent<MovingCircle>().enableRotation();
    }
    public void startMovingCircleRotation(int index, float rotationSpeed){
        activeMovingCircles[index].GetComponent<MovingCircle>().enableRotation(true, rotationSpeed);
    }
    public void stopMovingCircleRotation(int index){
        activeMovingCircles[index].GetComponent<MovingCircle>().stopRotation();
    }
    public void despawnMovingCircle(int index){
        activeMovingCircles[index].GetComponent<MovingCircle>().despawn();
        activeMovingCircles.RemoveAt(index);
    }

    /*
        MOVING TRIANGLE
    */
    public void movingTriangle(GameObject boss, int quantity, float width, float height, float speed, float direction){
        activeMovingTriangles.Add(Instantiate(movingTriangleHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeMovingTriangles[activeMovingTriangles.Count-1].GetComponent<MovingTriangle>().movingTriangle(bulletPrefab, quantity, width, height, speed, direction);
    }

    /*
    BULLET LINE
    */
    public void bulletLine(GameObject boss, int quantityLines, int quantityBullets, float spacing, float spawnTime, float offset)
    {
        activeBulletLines.Add(Instantiate(bulletLineHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeBulletLines[activeBulletLines.Count-1].GetComponent<BulletLine>().bulletLine(activeBulletLines[activeBulletLines.Count-1], bulletPrefab, quantityLines, quantityBullets, spacing, spawnTime, offset);
    }
    public void startBulletLineRotation(int index, float rotationSpeed){
        activeBulletLines[index].GetComponent<BulletLine>().startBulletLineRotation(rotationSpeed);
    }
    public void stopBulletLineRotation(int index){
        activeBulletLines[index].GetComponent<BulletLine>().stopBulletLineRotation();
    }
    public void despawnBulletLine(int index){
        activeBulletLines[index].GetComponent<BulletLine>().despawn();
        activeBulletLines.RemoveAt(index);
    }


    /*
    CONE
    */
    public void cone(GameObject boss, int quantity, float interval, float speed, float offset, float rotationSpeed, float spread){
        activeCones.Add(Instantiate(coneHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeCones[activeCones.Count-1].GetComponent<Cone>().cone(activeCones[activeCones.Count-1], bulletPrefab, quantity, interval, speed, offset, rotationSpeed, spread);
    }
    public void startCone(GameObject boss, float interval, float speed, float offset, float rotationSpeed, float spread){
        activeCones.Add(Instantiate(coneHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeCones[activeCones.Count-1].GetComponent<Cone>().startCone(activeCones[activeCones.Count-1], bulletPrefab, interval, speed, offset, rotationSpeed, spread);
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
    public void despawnCone(int index){
        activeCones[index].GetComponent<Cone>().despawn();
        activeCones.RemoveAt(index);
    }


    /* 
    LASER
    */

    // spawn a laser
    public void laser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length)
    {
        activeLasers.Add(Instantiate(laserHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeLasers[activeLasers.Count-1].GetComponent<SpinningLaser>().laser(activeLasers[activeLasers.Count-1], quantity, spawnTime, rotationSpeed, offset, length);
    }
    public void startLaser(GameObject boss, int quantity, float spawnTime, float rotationSpeed, float offset, float length){
        activeLasers.Add(Instantiate(laserHandler, boss.transform.position, new Quaternion(0,0,0,0), boss.transform));
        activeLasers[activeLasers.Count-1].GetComponent<SpinningLaser>().startLaser(activeLasers[activeLasers.Count-1], quantity, spawnTime, rotationSpeed, offset, length);
    }
    // public void stopLaser(int index){
    //     activeLasers[index].GetComponent<SpinningLaser>().stop();
    // }
    public void pauseLaser(int index){
        activeLasers[index].GetComponent<SpinningLaser>().pause();
    }
    public void resumeLaser(int index){
        activeLasers[index].GetComponent<SpinningLaser>().resume();
    }
    public void setLaserOffset(int index, float offset){
        activeLasers[index].GetComponent<SpinningLaser>().setOffset(offset);
    }
    public void setLaserRotationSpeed(int index, float speed){
        activeLasers[index].GetComponent<SpinningLaser>().setRotationSpeed(speed);
    }
    public void despawnLaser(int index){
        activeLasers[index].GetComponent<SpinningLaser>().despawn();
        activeLasers.RemoveAt(index);
    }

}
