using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] public ParticleSystem projectileParticle;
    

    public Waypoint waypointStand;
    [SerializeField] Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
        objectToPan.LookAt(targetEnemy);
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        EnemyDamage[] enemies = FindObjectsOfType<EnemyDamage>();
        if (enemies.Length == 0)
        {
            return;
        }
        EnemyDamage closestEnemy = enemies[0];
        float currentClosestDistance = Vector3.Distance(closestEnemy.transform.position, objectToPan.transform.position);
        foreach (EnemyDamage enemyInstance in enemies)
        {            
            float currentInstanceDistance = Vector3.Distance(enemyInstance.transform.position, objectToPan.transform.position);
            if (currentClosestDistance > currentInstanceDistance)
            {
                closestEnemy = enemyInstance;
                currentClosestDistance = currentInstanceDistance;
            }
        }
        targetEnemy = closestEnemy.transform;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            print(distanceToEnemy);
            print(attackRange);
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {        
        ParticleSystem.EmissionModule emissionModule = projectileParticle.emission;         
        emissionModule.enabled = isActive;
    }
}
