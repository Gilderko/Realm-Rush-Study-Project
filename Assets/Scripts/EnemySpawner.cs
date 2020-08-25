using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefarb;

    void Start()
    {
        StartCoroutine(SpawnEnemy());        
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 1; i <= 5; i++)
        {
            Instantiate(enemyPrefarb, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }


    
}
