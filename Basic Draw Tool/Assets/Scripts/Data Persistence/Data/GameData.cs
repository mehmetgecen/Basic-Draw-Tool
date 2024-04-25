using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<Vector2> linePositions;
    public List<Vector3> stampPositions;
    
    public Color canvasColor;
    
    public float brushSize;
    
    public Color brushColor;
    public float redSliderValue;
    public float greenSliderValue;
    public float blueSliderValue;

    public GameData()
    {
        linePositions = new List<Vector2>();
        stampPositions = new List<Vector3>();
        canvasColor = Color.white;
        brushSize = 1f;
        brushColor = Color.black;
        redSliderValue = 0f;
        greenSliderValue = 0f;
        blueSliderValue = 0f;
    }
}
