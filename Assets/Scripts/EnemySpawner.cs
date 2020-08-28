using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(1f,5f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] int enemiesToSpawn;
    [SerializeField] EnemyMovement enemyPrefarb;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] GameManager gameManager;    

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int count = 1; count <= enemiesToSpawn; count++)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(spawnSound);
            Instantiate(enemyPrefarb, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        gameManager.NoLongerSpawning();
    }
}
