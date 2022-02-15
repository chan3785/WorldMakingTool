using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DFadeCover : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }


    void Update()
    {
        Color color = image.color;
        if (Input.GetKey(KeyCode.D))
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * 10f;
            }
            image.color = color;
        }
        if (!Input.GetKey(KeyCode.D))
        {
            if (color.a < 1)
            {
                color.a += Time.deltaTime * 10f;
            }
            image.color = color;
        }
    }
}
