using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class SliderController : MonoBehaviour
{
    [SerializeField] Slider redSlider, greenSlider, blueSlider;
    [SerializeField] TextMeshProUGUI redValue, greenValue, blueValue;
    [SerializeField] Image colorPreview;
    public static Color color;
    void Start()
    {
        color = colorPreview.color;
        redSlider.onValueChanged.AddListener(OnSliderEvent);
        greenSlider.onValueChanged.AddListener(OnSliderEvent1);
        blueSlider.onValueChanged.AddListener(OnSliderEvent2);
    }
    public void OnSliderEvent(float value)
    {
        redValue.text = $"{value}";
        color.r = value;
        ChangeColor();
    }
    public void OnSliderEvent1(float value)
    {
        greenValue.text = $"{value}";
        color.g = value;
        ChangeColor();
    }
    public void OnSliderEvent2(float value)
    {
        blueValue.text = $"{value}";
        color.b = value;
        ChangeColor();
    }
    public void ChangeColor()
    {
        colorPreview.color = new Color(color.r / 255, color.g / 255, color.b / 255);
    }
}
