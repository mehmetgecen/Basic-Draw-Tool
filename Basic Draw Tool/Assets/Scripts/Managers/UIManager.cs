using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject colorPickerPanel;
    [SerializeField] GameObject brushResizerPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject eraserDeciderPanel;
    
    
    public void DisableColorPicker()
    {
        colorPickerPanel.SetActive(false);
    }
    
    public void DisableBrushResizer()
    {
        brushResizerPanel.SetActive(false);
    }
    
    public void DisableOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }
    
    public void DisableEraserDecider()
    {
        eraserDeciderPanel.SetActive(false);
    }
    
    public void EnableEraserDecider()
    {
        eraserDeciderPanel.SetActive(true);
    }
    
    public void EnableOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    
    public void ToggleBrushResizer()
    {
        brushResizerPanel.gameObject.SetActive(!brushResizerPanel.activeSelf);
    }
}
