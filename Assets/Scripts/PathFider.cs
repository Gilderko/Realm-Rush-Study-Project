using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFider : MonoBehaviour
{    
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Vector3[] directions = { new Vector3(10, 0, 0), new Vector3(-10, 0, 0), new Vector3(0, 0, 10), new Vector3(0, 0, -10) };

    Waypoint searchCenter;
    Dictionary<Vector3, Waypoint> worldGrid = new Dictionary<Vector3, Waypoint>();
    Queue<Waypoint> waypointQue = new Queue<Waypoint>();
    private List<Waypoint> enemyPath = new List<Waypoint>();
    
    public List<Waypoint> GetPath()
    {
        if (enemyPath.Count == 0 )
        {
            LoadBlocks();
            ColorStartAndEnd();
            BFSFindPath();
            CreatePath();
        }
        return enemyPath; 
    }

    private void CreatePath()
    {
        enemyPath.Add(endWaypoint);
        Waypoint currentWaypoint = endWaypoint.exploredFrom;
        while (currentWaypoint != startWaypoint)
        {
            enemyPath.Add(currentWaypoint);
            currentWaypoint = currentWaypoint.exploredFrom;
        }
        enemyPath.Add(currentWaypoint);
        enemyPath.Reverse();
    }

    private void BFSFindPath()
    {
        waypointQue.Enqueue(startWaypoint);
        while (waypointQue.Count > 0)
        {
            searchCenter = waypointQue.Dequeue();
            print("Searching from" + searchCenter.GetGridPos());
            if (searchCenter.GetGridPos() == endWaypoint.GetGridPos())
            {
                print("Found end");
                return;
            }
            ExploreNeighbours();
            searchCenter.current_state = Waypoint.WaypointState.discovered;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector3 direction in directions)
        {
            Vector3 neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (worldGrid.ContainsKey(neighbourCoordinates))
            {
                Waypoint neighbour = worldGrid[neighbourCoordinates];
                EnqueIfNotSeen(neighbour);
            }       
        }
    }

    private void EnqueIfNotSeen(Waypoint neighbour)
    {
        if (neighbour.current_state == Waypoint.WaypointState.unseen)
        {
            neighbour.exploredFrom = searchCenter;
            neighbour.current_state = Waypoint.WaypointState.seen;            
            waypointQue.Enqueue(neighbour);
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.red);
        endWaypoint.SetTopColor(Color.green);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (worldGrid.ContainsKey(waypoint.GetGridPos()))
            {
                continue;
            }
            else
            {
                worldGrid.Add(waypoint.GetGridPos(), waypoint);
            }      
        }
    }
}
