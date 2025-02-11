using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{
    public enum ToolType
    {
        Pen,
        Eraser,
        Bucket,
        Stamp,
        Idle
    }
    
    public ToolType currentTool = ToolType.Pen;
    
    [SerializeField] GameObject pen;
    [SerializeField] GameObject eraser;
    [SerializeField] GameObject bucket;
    [SerializeField] GameObject stamp;
    
    
    public Button penButton;
    public Button eraserButton;
    public Button bucketButton;
    public Button stampButton;
    
    public GameObject colorPicker;
    
    private void Start()
    {
        currentTool = ToolType.Idle;
        
        // Attach onClick events to each button
        penButton.onClick.AddListener(() => SetTool(ToolType.Pen));
        eraserButton.onClick.AddListener(() => SetTool(ToolType.Eraser));
        bucketButton.onClick.AddListener(() => SetTool(ToolType.Bucket));
        stampButton.onClick.AddListener(() => SetTool(ToolType.Stamp));
    }

    private void Update()
    {
        switch (currentTool)
        {
            case ToolType.Idle:
                pen.SetActive(false);
                eraser.SetActive(false);
                bucket.SetActive(false);
                stamp.SetActive(false);
                break;
            
            case ToolType.Pen:
                pen.SetActive(true);
                eraser.SetActive(false);
                bucket.SetActive(false);
                stamp.SetActive(false);
                break;
            case ToolType.Eraser:
                pen.SetActive(false);
                eraser.SetActive(true);
                bucket.SetActive(false);
                stamp.SetActive(false);
                break;
            case ToolType.Bucket:
                pen.SetActive(false);
                eraser.SetActive(false);
                bucket.SetActive(true);
                stamp.SetActive(false);
                break;
            case ToolType.Stamp:
                pen.SetActive(false);
                eraser.SetActive(false);
                bucket.SetActive(false);
                stamp.SetActive(true);
                break;
        }
    }
    
    public void SetTool(ToolType tool)
    {
        currentTool = tool;
        print(currentTool);
    }
    
    //enable and disable ui gameobjects
    public void EnableColorPicker()
    {
        colorPicker.SetActive(true);
    }
    
    public void DisableColorPicker()
    {
        colorPicker.SetActive(false);   
    }
}
