using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticleEnemy;
    [SerializeField] ParticleSystem deathParticleEnemy;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        ParticleSystem deathInstance = Instantiate(deathParticleEnemy,transform.position,Quaternion.identity);
        deathInstance.Play();        
        Destroy(gameObject);        
    }

    void ProcessHit()
    {
        hitPoints--;
        hitParticleEnemy.Play();
    }
}
