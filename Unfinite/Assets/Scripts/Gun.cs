using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun{
    float fireRate, damage, range, bulletSpeed;
    Texture2D gunTexture;
    public Gun(Part barrel, Part magazine, Part sight, Part stock){
        fireRate = ((((((((1 * stock.fireRateMult) + stock.fireRateFlat) * sight.fireRateMult) + sight.fireRateFlat) * magazine.fireRateMult) + magazine.fireRateFlat) * barrel.fireRateMult) + barrel.fireRateFlat);
        damage = ((((((((1 * stock.damageMult) + stock.damageFlat) * sight.damageMult) + sight.damageFlat) * magazine.damageMult) + magazine.damageFlat) * barrel.damageMult) + barrel.damageFlat);
        range = ((((((((1 * stock.rangeMult) + stock.rangeFlat) * sight.rangeMult) + sight.rangeFlat) * magazine.rangeMult) + magazine.rangeFlat) * barrel.rangeMult) + barrel.rangeFlat);
        bulletSpeed = ((((((((1 * stock.bulletSpeedMult) + stock.bulletSpeedFlat) * sight.bulletSpeedMult) + sight.bulletSpeedFlat) * magazine.bulletSpeedMult) + magazine.bulletSpeedFlat) * barrel.bulletSpeedMult) + barrel.bulletSpeedFlat);
        
    }
    public float getFireRate() { return fireRate; }
    public float getDamage() { return damage; }
    public float getRange() { return range; }
    public float getBulletSpeed() { return bulletSpeed; }

}
