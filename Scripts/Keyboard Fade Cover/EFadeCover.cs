using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class EFadeCover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed;
    [SerializeField] Image image1, image2;

    void Update()
    {
        if (isPressed)
        {
            GameObject.Find("CraftTab").GetComponent<Inventory>().RotateRightSmoothly();
        }
        if (Input.GetKey(KeyCode.LeftShift))
            FadeShiftE();

        else if (!Input.GetKey(KeyCode.LeftShift))
            FadeE();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void FadeE()
    {
        Color color = image1.color;
        if (Input.GetKey(KeyCode.E))
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * 10f;
            }
            image1.color = color;
        }
        if (!Input.GetKey(KeyCode.E))
        {
            if (color.a < 1)
            {
                color.a += Time.deltaTime * 10f;
            }
            image1.color = color;
        }
    }
    private void FadeShiftE()
    {
        Color color2 = image2.color;
        if (Input.GetKey(KeyCode.E))
        {
            if (color2.a > 0)
            {
                color2.a -= Time.deltaTime * 10f;
            }
            image2.color = color2;
        }
        if (!Input.GetKey(KeyCode.E))
        {
            if (color2.a < 1)
            {
                color2.a += Time.deltaTime * 10f;
            }
            image2.color = color2;
        }
    }
}