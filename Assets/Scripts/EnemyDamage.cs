using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticleEnemy;
    [SerializeField] ParticleSystem deathParticleEnemy;
    [SerializeField] AudioClip enemyHitSound;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] int enemyReward = 5;
    [SerializeField] GoldManager goldManager;
    GameObject audioListener;

    private void Start()
    {
        audioListener = GameObject.Find("Main Camera");
        goldManager = FindObjectOfType<GoldManager>();
    }

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
        ParticleSystem deathInstance = Instantiate(deathParticleEnemy,transform.position,Quaternion.identity,gameObject.transform.parent);
        deathInstance.Play();
        AudioSource.PlayClipAtPoint(enemyDeathSound, audioListener.transform.position);
        goldManager.AddGold(enemyReward);
        Destroy(gameObject);        
    }

    void ProcessHit()
    {
        hitPoints--;
        AudioSource.PlayClipAtPoint(enemyHitSound, audioListener.transform.position);
        hitParticleEnemy.Play();
    }
}
