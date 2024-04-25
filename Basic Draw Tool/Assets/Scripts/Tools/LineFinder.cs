using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFinder : MonoBehaviour
{
    private float _deletionDistance = 0.5f;
    public LineRenderer FindNearestLine(Vector2 position)
    {
        LineRenderer nearestLine = null;
        float minDistance = float.MaxValue;

        foreach (LineRenderer line in FindObjectsOfType<LineRenderer>())
        {
            for (int i = 0; i < line.positionCount; i++)
            {
                Vector2 linePosition = line.GetPosition(i);
                float distance = Vector2.Distance(linePosition, position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestLine = line;
                }
            }
        }

        return nearestLine;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main == null)
            {
                Debug.LogError("No camera tagged as MainCamera");
                return;
            }

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LineRenderer nearestLine = FindNearestLine(mousePosition);

            if (nearestLine == null)
            {
                Debug.LogError("No LineRenderer objects in scene");
                return;
            }

            float distanceBetweenPoints = Vector2.Distance(nearestLine.GetPosition(FindNearestLineIndex(mousePosition,nearestLine)),mousePosition);

            print("Distance" + distanceBetweenPoints);

            Debug.Log("Mouse Position" + mousePosition);

            if (distanceBetweenPoints < _deletionDistance)
            {
                int nearestLineIndex = FindNearestLineIndex(mousePosition,nearestLine);
                Destroy(nearestLine.gameObject);
            }
        }
    }
    
    //return nearest line renderer index from mouse position
    public int FindNearestLineIndex(Vector2 position, LineRenderer lineRenderer)
    {
        int nearestIndex = 0;
        float minDistance = float.MaxValue;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector2 linePosition = lineRenderer.GetPosition(i);
            float distance = Vector2.Distance(linePosition, position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }
    
    public void RemovePoints(int startIndex, int count,LineRenderer lineRenderer)
    {
        if (lineRenderer != null)
        {
            int originalCount = lineRenderer.positionCount;

            // Ensure the start index is within bounds
            startIndex = Mathf.Clamp(startIndex, 0, originalCount - 1);

            // Calculate the new count after removing the specified points
            int newCount = Mathf.Clamp(originalCount - count, 0, originalCount);

            // Create a new array to hold the updated positions
            Vector3[] newPositions = new Vector3[newCount];

            // Copy the positions before the removed points
            for (int i = 0; i < startIndex; i++)
            {
                newPositions[i] = lineRenderer.GetPosition(i);
            }

            // Copy the positions after the removed points
            for (int i = startIndex + count; i < originalCount; i++)
            {
                newPositions[i - count] = lineRenderer.GetPosition(i);
            }

            // Update the LineRenderer with the new positions
            lineRenderer.positionCount = newCount;
            lineRenderer.SetPositions(newPositions);
        }
    }
    
    
}
