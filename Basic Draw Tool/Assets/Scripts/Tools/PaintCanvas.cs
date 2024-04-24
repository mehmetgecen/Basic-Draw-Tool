using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PaintCanvas : MonoBehaviour
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
        /*if (InteractWithUI())
        {
            return;
        }*/
        
        if (Input.GetMouseButton(0) && InteractWithUI())
        {
            ClearLines();
            ClearEraserLines();
            FillCanvasWithColor();
            audioSource.Play();
            
        }
    }

    public void FillCanvasWithColor()
    {
        // Fill the canvas with the selected color
        Camera.main.backgroundColor = colorPicker.GetCurrentColor();
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
    
}
