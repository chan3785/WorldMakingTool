using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class SliderController : MonoBehaviour
{
    [SerializeField] Slider redSlider, greenSlider, blueSlider;
    [SerializeField] TextMeshProUGUI redValue, greenValue, blueValue;
    [SerializeField] SpriteRenderer colorPreview;
    void Start()
    {
        redSlider.onValueChanged.AddListener(OnSliderEvent);
        greenSlider.onValueChanged.AddListener(OnSliderEvent1);
        blueSlider.onValueChanged.AddListener(OnSliderEvent2);
    }
    public void OnSliderEventColor(float red, float green, float blue)
    {
        Color color = colorPreview.color;
        color.r = red;
        color.g = green;
        color.b = blue;
        colorPreview.color = color;
    }

    public void OnSliderEvent(float value)
    {
        redValue.text = $"{value}";
    }
    public void OnSliderEvent1(float value)
    {
        greenValue.text = $"{value}";
    }
    public void OnSliderEvent2(float value)
    {
        blueValue.text = $"{value}";
    }
}
