using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    LineRenderer lineRenderer;


    private void Awake()
    {
        lineRenderer = FindObjectOfType<LineRenderer>();
    }

    private void Update()
    {
        HandleEraseInput();
    }

    private void HandleEraseInput()
    {
        // Implement erasing logic here
        if (Input.GetMouseButton(0)) // Left mouse button is held down
        {
            Vector3 mousePos = GetMouseWorldPosition();
            ErasePointFromLine(mousePos);
        }
    }

    private void ErasePointFromLine(Vector3 point)
    {
        // Find the nearest point on the line renderer and remove it
        int nearestIndex = FindNearestPointIndex(point);
        if (nearestIndex != -1)
        {
            lineRenderer.positionCount--;

            // Shift the remaining points to fill the gap
            for (int i = nearestIndex; i < lineRenderer.positionCount; i++)
            {
                lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
            }
        }
    }

    private int FindNearestPointIndex(Vector3 point)
    {
        int nearestIndex = -1;
        float minDistance = float.MaxValue;

        // Iterate through all points to find the nearest one
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float distance = Vector3.Distance(point, lineRenderer.GetPosition(i));
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in the world space
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10; // Adjust the distance from the camera
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
