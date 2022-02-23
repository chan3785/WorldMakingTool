using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SFadeCover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if (isPressed)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().InputS();
        }
        FadeS();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void FadeS()
    {
        Color color = image.color;
        if (Input.GetKey(KeyCode.S))
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * 10f;
            }
            image.color = color;
        }
        if (!Input.GetKey(KeyCode.S))
        {
            if (color.a < 1)
            {
                color.a += Time.deltaTime * 10f;
            }
            image.color = color;
        }
    }
}
