using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstTower : Tower
{
    public static float burstAttackSpeedUpgrade = 0;
    private float burstAttackSpeedBaseVal = 0.5f;

    public static float burstFrequencyUpgrade = 0f;
    private float burstFrequencyBaseVal = 1f;

    public static int towerLvl = 0;


    private void Start()
    {
        UpdateAttackSpeed();
        UpdateBurstFrequency();
    }

    private void UpdateAttackSpeed()
    {
        ParticleSystem.EmissionModule emmisionBullets = this.projectileParticle.emission;
        emmisionBullets.rateOverTime = burstAttackSpeedBaseVal + burstAttackSpeedUpgrade;
    }

    private void UpdateBurstFrequency()
    {
        ParticleSystem.EmissionModule emmisionBullets = this.projectileParticle.emission;
        var burst = emmisionBullets.GetBurst(0);
        burst.repeatInterval = burstFrequencyBaseVal - burstFrequencyUpgrade;
        emmisionBullets.SetBurst(0, burst);
    }
}
