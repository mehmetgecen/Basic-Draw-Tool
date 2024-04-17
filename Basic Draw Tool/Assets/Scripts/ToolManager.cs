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
        Stamp
    }
    
    public ToolType currentTool = ToolType.Pen;
    
    public Button penButton;
    public Button eraserButton;
    public Button bucketButton;
    public Button stampButton;
    
    private void Start()
    {
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
            case ToolType.Pen:
                //HandleDrawInput();
                break;
            case ToolType.Eraser:
               // HandleEraseInput();
                break;
            case ToolType.Bucket:
                // HandleBucketInput();
                break;
            case ToolType.Stamp:
               // HandleStampInput();
                break;
        }
    }
    
    public void SetTool(ToolType tool)
    {
        currentTool = tool;
        print(currentTool);
    }
}
