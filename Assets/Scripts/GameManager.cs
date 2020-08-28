using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isStillSpawning = true;
    [SerializeField] float waitForNextLevel = 2f;
    
    void Update()
    {
        if (!isStillSpawning && FindObjectsOfType<EnemyMovement>().Length == 0)
        {
            StartCoroutine(LoadNextLevel());
        }        
    }

    public void NoLongerSpawning()
    {
        isStillSpawning = false;
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(waitForNextLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
