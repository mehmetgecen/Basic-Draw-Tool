using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public ToolManager.ToolType toolIdentity;
    public ColorPicker colorPicker;
    public BrushResizer brushResizer;
    Line activeLine;
    
    private void Update()
    {
        if (InteractWithUI())
        {
            return;
        }
        
        SetLineWidth();
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();

            if (colorPicker!= null)
            {
                activeLine.lineRenderer.material.color = colorPicker.GetCurrentColor();
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine!= null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePosition);
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
    
    //set line width
    public void SetLineWidth()
    {
        if (activeLine != null)
        {
            brushResizer.SetLineRendererWidth(activeLine.lineRenderer);
        }
    }
    
   
}
