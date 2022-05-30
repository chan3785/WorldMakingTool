using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;
    public Slot dragSlot;

    [SerializeField] private Image imageItem;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;
        SetColor(1);
    }

    public void SetColor(float alpha)
    {
        Color color = imageItem.color;
        color.a = alpha;
        imageItem.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
