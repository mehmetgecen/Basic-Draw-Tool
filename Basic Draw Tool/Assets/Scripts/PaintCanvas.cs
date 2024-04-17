using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
    public Color selectedColor;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ClearLines();
            ClearEraserLines();
            FillCanvasWithColor();
        }
    }

    public void FillCanvasWithColor()
    {
        // Fill the canvas with the selected color
        Camera.main.backgroundColor = selectedColor;
    }
    
    //Destroy Line and Eraser Line Gameobjects
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
    
}
