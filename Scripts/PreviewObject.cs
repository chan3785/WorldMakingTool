using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    List<Collider> colliderList = new List<Collider>();

    [SerializeField]
    int layerGround;
    const int IGNORE_RAYCAST_LAYER = 2;

    [SerializeField]
    Material green, red;

    void Update()
    {
        ChangeColor();
    }
    void ChangeColor()
    {
        if (colliderList.Count > 0)
            SetColor(red, this.transform);
        else
            SetColor(green, this.transform);
    }
    public static void SetColor(Material mat, Transform tf_parameter)
    {
        foreach (Transform tf_Child in tf_parameter)
        {
            var newMaterials = new Material[tf_Child.GetComponent<Renderer>().materials.Length];


            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = mat;
            }
            tf_Child.GetComponent<Renderer>().materials = newMaterials;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
            colliderList.Add(other);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
            colliderList.Remove(other);
    }

    public bool IsBuildable()
    {
        return colliderList.Count == 0;
    }
}
