using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCanvas : MonoBehaviour
{
    public void ClearCanvasObjects()
    {
        ClearLines();
        ClearEraserLines();
        ClearAllStamps();
        ClearCanvasColor();
    }
    
    
    public void ClearLines()
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
    }
    
    public void ClearEraserLines()
    {
        // Destroy all Line objects in the scene
        GameObject[] eraserLines = GameObject.FindGameObjectsWithTag("Eraser Line");
        foreach (GameObject line in eraserLines)
        {
            Destroy(line);
        }
    }

    public void ClearAllStamps()
    {
        GameObject[] stamps = GameObject.FindGameObjectsWithTag("Stamp");
        foreach (GameObject stamp in stamps)
        {
            Destroy(stamp);
        }
    }
    
    public void ClearCanvasColor()
    {
        Camera.main.backgroundColor = Color.white;
    }
}
