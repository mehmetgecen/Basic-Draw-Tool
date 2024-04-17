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
    
    [SerializeField] GameObject pen;
    [SerializeField] GameObject eraser;
    //[SerializeField] GameObject bucket;
    //[SerializeField] GameObject stamp;
    
    
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
                pen.SetActive(true);
                eraser.SetActive(false);
                break;
            case ToolType.Eraser:
                pen.SetActive(false);
                eraser.SetActive(true);
                break;
            case ToolType.Bucket:
                pen.SetActive(false);
                break;
            case ToolType.Stamp:
                pen.SetActive(false);
                break;
        }
    }
    
    public void SetTool(ToolType tool)
    {
        currentTool = tool;
        print(currentTool);
    }
}
