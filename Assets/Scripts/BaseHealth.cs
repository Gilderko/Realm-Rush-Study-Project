using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int healthPoints;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip baseDamage;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        healthText.text = "Base health: " + healthPoints.ToString();        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(baseDamage);
        healthPoints--;
        if (healthPoints <= 0)
        {
            Time.timeScale = 0;
            gameManager.RestartLevel();
        }
        healthText.text = "Base health: " + healthPoints.ToString();
        other.gameObject.transform.parent.GetComponent<EnemyMovement>().EnemyReachedEnd();
    }
}
