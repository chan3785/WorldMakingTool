using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DFadeCover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    Image image1;
    void Start()
    {
        image1 = GetComponent<Image>();
    }
    void Update()
    {
        if (isPressed)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().InputD();
        }
        FadeD();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void FadeD()
    {
        Color color = image1.color;
        if (Input.GetKey(KeyCode.D))
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * 10f;
            }
            image1.color = color;
        }
        if (!Input.GetKey(KeyCode.D))
        {
            if (color.a < 1)
            {
                color.a += Time.deltaTime * 10f;
            }
            image1.color = color;
        }
    }
}