using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector3 gridPos;
    public enum WaypointState { unseen, seen, discovered }
    public WaypointState current_state = WaypointState.unseen;
    const int gridSize = 10;
    public Waypoint exploredFrom;

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
        print("Your mouse is over" + gameObject.transform);
    }

}
