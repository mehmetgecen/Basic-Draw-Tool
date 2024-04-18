using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Image colorPreviewImage;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    private Color currentColor;

    void Start()
    {
        currentColor = Color.white;
        UpdateColorPreview();
    }

    public void OnColorChanged()
    {
        float r = redSlider.value;
        float g = greenSlider.value;
        float b = blueSlider.value;
        currentColor = new Color(r, g, b);
        UpdateColorPreview();
    }

    void UpdateColorPreview()
    {
        colorPreviewImage.color = currentColor;
    }

    // Function to get the currently selected color
    public Color GetCurrentColor()
    {
        return currentColor;
    }
}
