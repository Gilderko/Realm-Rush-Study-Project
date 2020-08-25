using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    
    List<Waypoint> enemyPath = new List<Waypoint>();
    void Start()
    {
        PathFider pathFinder = FindObjectOfType<PathFider>();
        enemyPath = pathFinder.GetPath();
        StartCoroutine(FollowPath(enemyPath));
    }
    
    IEnumerator FollowPath(List<Waypoint> followPath)
    {
        //print("Starting FollowPath");
        foreach (Waypoint waypointBlock in followPath)
        {
            transform.position = new Vector3(waypointBlock.transform.position.x,transform.position.y, waypointBlock.transform.position.z);
            //print("Visiting " + waypointBlock.name);
            yield return new WaitForSeconds(waitTime);
        }
        //print("Ending FollowPath");
    }
    
}
