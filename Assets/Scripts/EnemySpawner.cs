using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1f,5f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefarb;

    void Start()
    {
        StartCoroutine(SpawnEnemy());        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefarb, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }


    
}
