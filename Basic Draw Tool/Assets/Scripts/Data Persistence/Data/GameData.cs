using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<Vector3> linePositions;
    public List<Vector3> stampPositions;
    
    public Color canvasColor;
    
    public float brushSize;
    
    public Color brushColor;
    public float redSliderValue;
    public float greenSliderValue;
    public float blueSliderValue;
    public List<Vector2> linePoints;
    public List<List<Vector2>> lines;

    public GameData()
    {
        lines = new List<List<Vector2>>();
        linePositions = new List<Vector3>();
        stampPositions = new List<Vector3>();
        canvasColor = Color.white;
        brushSize = 50f;
        brushColor = Color.black;
        redSliderValue = 0f;
        greenSliderValue = 0f;
        blueSliderValue = 0f;
        
        linePoints = new List<Vector2>();
    }
}
