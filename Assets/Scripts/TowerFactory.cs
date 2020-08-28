using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int maxTowerCount;
    public static Tower towerPrefarb;        
    Queue<Tower> waypointQueBuffer = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        Vector3 towerPosition = baseWaypoint.transform.position;
        towerPosition.y += 10;

        if (maxTowerCount > waypointQueBuffer.Count)
        {            
            Tower newTower = Instantiate(towerPrefarb, towerPosition, Quaternion.identity, transform);            
            newTower.waypointStand = baseWaypoint;
            waypointQueBuffer.Enqueue(newTower);
            print("Placed tower over " + baseWaypoint.transform.position);
        }
        else
        {
            Tower towerToMove = waypointQueBuffer.Dequeue();
            towerToMove.waypointStand.isBlocked = false;
            towerToMove.transform.position = towerPosition;
            towerToMove.waypointStand = baseWaypoint;
            waypointQueBuffer.Enqueue(towerToMove);
            print("Moved tower to " + baseWaypoint.transform.position);
        }
        baseWaypoint.isBlocked = true;
    }
}
