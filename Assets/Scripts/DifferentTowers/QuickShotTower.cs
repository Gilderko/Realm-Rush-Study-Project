using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickShotTower : Tower
{
    public static float attackSpeedUpgrade = 0f;
    private float attackSpeedBaseVal = 4f;

    public static float accuracyUpgrade = 0f;
    private float accuracyBaseVal = 0.3f;

    public static int towerLvl = 0;

    private void Start()
    {
        UpdateAttackSpeed();
        UpdateParticleAccuracy();
    }

    private void UpdateAttackSpeed()
    {
        ParticleSystem.EmissionModule emmisionBullets = this.projectileParticle.emission;
        emmisionBullets.rateOverTime = attackSpeedBaseVal + attackSpeedUpgrade;
    }

    private void UpdateParticleAccuracy()
    {
        ParticleSystem.ShapeModule shapeBullets = this.projectileParticle.shape;
        shapeBullets.randomDirectionAmount = accuracyBaseVal - accuracyUpgrade;
    }
}
