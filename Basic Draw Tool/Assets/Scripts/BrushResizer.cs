using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushResizer : MonoBehaviour
{
    [SerializeField] private float previewSizeFactor = 200f;
    [SerializeField] private float defaultSize;
    public ColorPicker colorPicker;
    public Slider sizeSlider; 
    public Image previewImage;
    private float _currentSize;
    

    private void Start()
    {
        defaultSize = sizeSlider.value * previewSizeFactor ;
        _currentSize = defaultSize;
        UpdatePreview();
    }

    public void OnSizeChanged()
    {
        _currentSize = sizeSlider.value * previewSizeFactor;
        UpdatePreview();
    }
    
    // Update the preview image with the current brush size
    void UpdatePreview()
    {
        previewImage.rectTransform.sizeDelta = new Vector2(_currentSize, _currentSize);
        previewImage.color = colorPicker.GetCurrentColor();
    }
    
    // Function to get the currently selected brush size
    public float GetCurrentSize()
    {
        return _currentSize;
    }
    
    public void SetCurrentSize(float size)
    {
        _currentSize = size;
        sizeSlider.value = _currentSize / previewSizeFactor;
        UpdatePreview();
    }
    
    public void SetLineRendererWidth(LineRenderer lineRenderer)
    {
        lineRenderer.startWidth = _currentSize / previewSizeFactor;
        lineRenderer.endWidth = _currentSize / previewSizeFactor;
    }
}
