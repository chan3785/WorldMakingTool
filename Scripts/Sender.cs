
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    Renderer rend;
    [SerializeField] GameObject Left, Right, Back, Front;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        WallSetMessage();
    }
    void WallSetMessage()
    {
        Left.SendMessage("OnOff");
        Right.SendMessage("OnOff");
        Front.SendMessage("OnOff");
        Back.SendMessage("OnOff");
    }

    void OnMouseEnter()
    {
        rend.material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
}
