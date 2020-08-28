using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstTower : Tower
{
    public static int burstAmountUpgrade = 0;
    private int burstAmountBaseVal = 3;

    public static float burstFrequencyUpgrade = 0f;
    private float burstFrequencyBaseVal = 0.9f;

    public static int towerLvl = 0;


    private void Start()
    {
        UpdateBurstAmount();
        UpdateBurstFrequency();
    }

    private void UpdateBurstAmount()
    {
        ParticleSystem.EmissionModule emmisionBullets = this.projectileParticle.emission;
        var burst = emmisionBullets.GetBurst(0);
        burst.minCount = burst.maxCount = (short)(burstAmountBaseVal + burstAmountUpgrade);
        emmisionBullets.SetBurst(0, burst);
    }

    private void UpdateBurstFrequency()
    {
        ParticleSystem.EmissionModule emmisionBullets = this.projectileParticle.emission;
        var burst = emmisionBullets.GetBurst(0);
        burst.repeatInterval = burstFrequencyBaseVal - burstFrequencyUpgrade;
        emmisionBullets.SetBurst(0, burst);
    }
}
