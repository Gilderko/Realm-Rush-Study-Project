using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int healthPoints;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = "Base health: " + healthPoints.ToString();        
    }

    private void OnTriggerEnter(Collider other)
    {
        healthPoints--;
        healthText.text = "Base health: " + healthPoints.ToString();
        other.gameObject.transform.parent.GetComponent<EnemyMovement>().EnemyReachedEnd();
    }
}
