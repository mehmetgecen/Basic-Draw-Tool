using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PaintCanvas : MonoBehaviour, IDataPersistence
{
    [SerializeField] private AudioClip fillSound;
    public ColorPicker colorPicker;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fillSound;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !InteractWithUI())
        {
            ClearLines();
            ClearEraserLines();
            FillCanvasWithColor();
            audioSource.Play();
            
        }
    }

    public void FillCanvasWithColor()
    {
        if (Camera.main != null)
        {
            if (colorPicker != null)
            {
                Camera.main.backgroundColor = colorPicker.GetCurrentColor();
            }
            else
            {
                Debug.LogError("colorPicker is null");
            }
        }
        else
        {
            Debug.LogError("No camera tagged as MainCamera");
        }
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
    
    private bool InteractWithUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        return false;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.canvasColor = Camera.main.backgroundColor;
    }

    public void LoadData(GameData gameData)
    {
        if (Camera.main != null)
        {
            Camera.main.backgroundColor = gameData.canvasColor;
        }
        else
        {
            Debug.LogError("No camera tagged as MainCamera");
        }
    }
}
