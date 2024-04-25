using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour,IDataPersistence
{
    public Image colorPreviewImage;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    private Color currentColor;

    

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

    public void SaveData(ref GameData gameData)
    {
        //save slider values
        gameData.redSliderValue = redSlider.value;
        gameData.greenSliderValue = greenSlider.value;
        gameData.blueSliderValue = blueSlider.value;
        gameData.brushColor = currentColor;
    }

    public void LoadData(GameData gameData)
    {
        //load slider values
        redSlider.value = gameData.redSliderValue;
        greenSlider.value = gameData.greenSliderValue;
        blueSlider.value = gameData.blueSliderValue;
        currentColor = gameData.brushColor;
        UpdateColorPreview();
    }
}
