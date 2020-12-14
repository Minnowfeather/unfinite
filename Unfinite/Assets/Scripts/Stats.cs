using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    //public float damageFlat, damageMult, rangeFlat, rangeMult, bulletSpeedFlat, bulletSpeedMult, fireRateFlat, fireRateMult;
    public Stats(float damageFlat, float damageMult, float rangeFlat, float rangeMult, float bulletSpeedFlat, float bulletSpeedMult, float fireRateFlat, float fireRateMult)
    {
        this.damageFlat = damageFlat;
        this.damageMult = damageMult;
        this.rangeFlat = rangeFlat;
        this.rangeMult = rangeMult;
        this.bulletSpeedFlat = bulletSpeedFlat;
        this.bulletSpeedMult = bulletSpeedMult;
        this.fireRateFlat = fireRateFlat;
        this.fireRateMult = fireRateMult;
    }
    public float damageFlat { get; }
    public float damageMult { get; }
    public float rangeFlat { get; }
    public float rangeMult { get; }
    public float bulletSpeedFlat { get; }
    public float bulletSpeedMult { get; }
    public float fireRateFlat { get; }
    public float fireRateMult { get; }
}
