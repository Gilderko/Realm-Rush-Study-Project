using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class EditorSnap : MonoBehaviour
{
    TextMesh textLabel;
    Waypoint waypointObject;

    private void Awake()
    {
        waypointObject = GetComponent<Waypoint>();        
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {  
        transform.position = waypointObject.GetGridPos();
    }    

    private void UpdateLabel()
    {
        textLabel = GetComponentInChildren<TextMesh>();
        Vector3 snapPos = waypointObject.GetGridPos();
        string labelText = "[" + snapPos.x + "," + snapPos.z + "]";
        gameObject.name = "Waypoint " + labelText;
        textLabel.text = labelText;
    }
}
