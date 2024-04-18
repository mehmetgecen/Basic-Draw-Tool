using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject colorPickerPanel;
    
    
    public void DisableColorPicker()
    {
        colorPickerPanel.SetActive(false);
    }
}
