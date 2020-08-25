using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector3 gridPos;
    public enum WaypointState { unseen, seen, discovered }
    public WaypointState current_state = WaypointState.unseen;
    public bool isBlocked = false;
    [SerializeField] Tower towerPrefarb;
    [SerializeField] GameObject towerSpawnParent;

    const int gridSize = 10;
    public Waypoint exploredFrom;

    private void Start()
    {
        towerSpawnParent = GameObject.Find("Towers");
    }


    public Vector3 GetGridPos()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        return snapPos;
    }

    public void SetTopColor(Color topColor)
    {
        MeshRenderer topMeshRender = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRender.material.color = topColor;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isBlocked)
            {
                Vector3 towerPosition = transform.position;
                towerPosition.y += 10;
                Instantiate(towerPrefarb, towerPosition, Quaternion.identity, towerSpawnParent.transform);
                isBlocked = true;
                print("Placed tower over " + gameObject.transform);
            }
           
        }
        
    }

}
