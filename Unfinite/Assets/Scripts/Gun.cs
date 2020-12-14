using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun{
    float fireRate, damage, range, bulletSpeed;
    Texture2D gunTexture;
    public Gun(Part barrel, Part magazine, Part sight, Part stock){
        fireRate = ((((((((1 * stock.stats.fireRateMult) + stock.stats.fireRateFlat) * sight.stats.fireRateMult) + sight.stats.fireRateFlat) * magazine.stats.fireRateMult) + magazine.stats.fireRateFlat) * barrel.stats.fireRateMult) + barrel.stats.fireRateFlat);
        damage = ((((((((1 * stock.stats.damageMult) + stock.stats.damageFlat) * sight.stats.damageMult) + sight.stats.damageFlat) * magazine.stats.damageMult) + magazine.stats.damageFlat) * barrel.stats.damageMult) + barrel.stats.damageFlat);
        range = ((((((((1 * stock.stats.rangeMult) + stock.stats.rangeFlat) * sight.stats.rangeMult) + sight.stats.rangeFlat) * magazine.stats.rangeMult) + magazine.stats.rangeFlat) * barrel.stats.rangeMult) + barrel.stats.rangeFlat);
        bulletSpeed = ((((((((1 * stock.stats.bulletSpeedMult) + stock.stats.bulletSpeedFlat) * sight.stats.bulletSpeedMult) + sight.stats.bulletSpeedFlat) * magazine.stats.bulletSpeedMult) + magazine.stats.bulletSpeedFlat) * barrel.stats.bulletSpeedMult) + barrel.stats.bulletSpeedFlat);
        
    }
    public float getFireRate() { return fireRate; }
    public float getDamage() { return damage; }
    public float getRange() { return range; }
    public float getBulletSpeed() { return bulletSpeed; }

}
