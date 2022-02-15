
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    int BoolCounter = 0;
    Collider mesh;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        mesh = GetComponent<Collider>();
        rend.enabled = false;
        mesh.enabled = false;
    }

    void OnOff()
    {
        BoolCounter++;
        if (BoolCounter % 2 == 0)
        {
            rend.enabled = false;
            mesh.enabled = false;
        }
        else
        {
            rend.enabled = true;
            mesh.enabled = true;
        }
    }
}
