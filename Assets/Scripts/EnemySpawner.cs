using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(1f,5f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefarb;
    [SerializeField] AudioClip spawnSound;
    

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(spawnSound);
            Instantiate(enemyPrefarb, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }        
    }
}
