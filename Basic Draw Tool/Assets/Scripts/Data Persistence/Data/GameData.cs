using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<Vector2> linePositions;
    public List<Vector3> stampPositions;
    public Color backgroundColor;
    public Color canvasColor;
    
    /*
    //brush size of line object
    public float brushSize;

    //brush color of line object
    public Color brushColor;*/
    
    public GameData()
    {
        linePositions = new List<Vector2>();
        stampPositions = new List<Vector3>();
        backgroundColor = Color.red;
        canvasColor = Color.white;
    }
}
