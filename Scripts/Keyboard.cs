using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [SerializeField] Image wButton, sButton, aButton, dButton;
    void Start()
    {
        ComponentFactory(wButton);
        ComponentFactory(sButton);
        ComponentFactory(aButton);
        ComponentFactory(dButton);
    }

    void Update()
    {
        float verticalAxis = Input.GetAxisRaw("Vertical");
        Color color = wButton.color;
        if (verticalAxis > 0)
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * 10f;
            }
            wButton.color = color;
        }
        if (verticalAxis == 0)
        {
            if (color.a < 1)
            {
                color.a += Time.deltaTime * 10f;
            }
            wButton.color = color;
        }
    }
    void ComponentFactory(Image image)
    {
        image = GetComponent<Image>();
    }
}
