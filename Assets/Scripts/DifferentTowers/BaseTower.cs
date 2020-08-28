using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : Tower
{
    public static float attackSpeedUpgrade = 0f;
    private float attackSpeedBaseVal = 1.05f + attackSpeedUpgrade;

    public static float particleSpeedUpgrade = 0f;
    private float particleSpeedBaseVal = 400f;

    public static int towerLvl = 0;

    private void Start()
    {
        UpdateAttackSpeed();
        UpdateParticleSpeed();
    }

    private void UpdateAttackSpeed()
    {
        ParticleSystem.EmissionModule emmisionBullets = this.projectileParticle.emission;
        emmisionBullets.rateOverTime = attackSpeedBaseVal + attackSpeedUpgrade;
    }

    private void UpdateParticleSpeed()
    {
        this.projectileParticle.startSpeed = particleSpeedBaseVal + particleSpeedUpgrade;
    }
}
