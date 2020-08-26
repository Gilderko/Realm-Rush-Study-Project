using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int healthPoints;

    private void OnTriggerEnter(Collider other)
    {
        healthPoints--;
    }
}
