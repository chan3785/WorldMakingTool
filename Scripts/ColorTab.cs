using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTab : MonoBehaviour
{
    bool isActivated;
    [SerializeField] GameObject go_BaseUi;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            Window();
    }
    public void Window()
    {
        if (!isActivated)
            OpenWindow();
        else
            CloseWindow();
    }
    void OpenWindow()
    {
        isActivated = true;
        go_BaseUi.SetActive(true);
    }
    void CloseWindow()
    {
        isActivated = false;
        go_BaseUi.SetActive(false);
    }
}
