using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject colorPickerPanel;
    [SerializeField] GameObject brushResizerPanel;
    
    
    public void DisableColorPicker()
    {
        colorPickerPanel.SetActive(false);
    }
    
    public void DisableBrushResizer()
    {
        brushResizerPanel.SetActive(false);
    }
    
    public void ToggleBrushResizer()
    {
        brushResizerPanel.gameObject.SetActive(!brushResizerPanel.activeSelf);
    }
}
