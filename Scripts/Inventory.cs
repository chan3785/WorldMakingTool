using UnityEngine;
using UnityEngine.EventSystems;
[System.Serializable]
public class Craft
{
    public string craftName;
    public GameObject go_Prefab;
    public GameObject go_PreviewPrefab;
}

public class Inventory : MonoBehaviour
{
    bool isActivated = false;
    [SerializeField] GameObject go_BaseUi;
    bool isPreviewActivated = false;

    [SerializeField] Craft[] craft_booth;
    GameObject go_Preview;
    GameObject go_Prefab;
    GameObject clone;
    [SerializeField] GameObject escapeButton;
    GameObject to_Destroy;
    [SerializeField] Transform tf_Player;
    RaycastHit hitinfo;
    [SerializeField] LayerMask layerMask, buildLayer, colorLayer;
    [SerializeField] float range, angle;
    float rotateSpeed;
    int tagingnum = 0;
    public GameObject to_Colorit;
    Quaternion currentRotation;
    public void SlotClick(int _slotNumber)
    {
        if (!isPreviewActivated)
        {
            go_Preview = Instantiate(craft_booth[_slotNumber].go_PreviewPrefab, tf_Player.position + tf_Player.forward, Quaternion.identity);
            go_Prefab = craft_booth[_slotNumber].go_Prefab;
            go_BaseUi.SetActive(false);
            isPreviewActivated = true;
            currentRotation = Quaternion.identity;
        }
    }
    void PreviewCancle()
    {
        if (isPreviewActivated)
        {
            escapeButton.SetActive(true);
        }
        if (!isPreviewActivated)
        {
            escapeButton.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPreviewActivated)
            Window();

        if (Input.GetKeyDown(KeyCode.Escape))
            Cancle();

        if (isPreviewActivated)
        {
            PreviewPositionUpdate();
        }
        RotateObject();
        PreviewCancle();
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
    public void RotateObject()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RotateStrictly();
        }
        else
        {
            RotateSmoothly();
        }
    }
    public void RotateLeftStrictly()
    {
        if (isPreviewActivated)
        {
            go_Preview.transform.eulerAngles -= new Vector3(0f, 15f, 0f);
            currentRotation = go_Preview.transform.rotation;
        }
    }
    public void RotateRightStrictly()
    {
        if (isPreviewActivated)
        {
            go_Preview.transform.eulerAngles += new Vector3(0f, 15f, 0f);
            currentRotation = go_Preview.transform.rotation;
        }
    }
    public void RotateLeftSmoothly()
    {
        if (isPreviewActivated)
        {
            rotateSpeed = angle * Time.deltaTime;
            go_Preview.transform.Rotate(0f, -rotateSpeed, 0f);
            currentRotation = go_Preview.transform.rotation;
        }
    }
    public void RotateRightSmoothly()
    {
        if (isPreviewActivated)
        {
            rotateSpeed = angle * Time.deltaTime;
            go_Preview.transform.Rotate(0f, rotateSpeed, 0f);
            currentRotation = go_Preview.transform.rotation;
        }
    }

    private void RotateStrictly()
    {
        if (isPreviewActivated)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                go_Preview.transform.eulerAngles -= new Vector3(0f, 15f, 0f);
                currentRotation = go_Preview.transform.rotation;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                go_Preview.transform.eulerAngles += new Vector3(0f, 15f, 0f);
                currentRotation = go_Preview.transform.rotation;
            }
        }
    }
    private void RotateSmoothly()
    {
        if (isPreviewActivated)
        {
            rotateSpeed = angle * Time.deltaTime;
            if (Input.GetKey(KeyCode.Q))
            {
                go_Preview.transform.Rotate(0f, -rotateSpeed, 0f);
                currentRotation = go_Preview.transform.rotation;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                go_Preview.transform.Rotate(0f, rotateSpeed, 0f);
                currentRotation = go_Preview.transform.rotation;
            }
        }
    }

    public void Build()
    {
        if (isPreviewActivated && go_Preview.GetComponent<PreviewObject>().IsBuildable())
        {
            PreviewPositionUpdate();
            clone = Instantiate(go_Prefab, hitinfo.point, currentRotation);
            clone.name += tagingnum;
            Destroy(go_Preview);
            isPreviewActivated = false;
            isActivated = false;
            tagingnum++;
        }
    }

    void PreviewPositionUpdate()
    {
        if (Physics.Raycast(tf_Player.position, tf_Player.forward, out hitinfo, range, layerMask))
        {
            if (hitinfo.transform != null)
            {
                Vector3 _location = hitinfo.point;
                go_Preview.transform.position = _location;
            }
        }
    }
    public void Cancle()
    {
        if (isPreviewActivated)
            Destroy(go_Preview);

        isActivated = false;
        isPreviewActivated = false;
        go_Preview = null;
        go_BaseUi.SetActive(false);
    }

    public void DestroyRay()
    {
        Physics.Raycast(tf_Player.position, tf_Player.forward, out hitinfo, range, buildLayer);
        to_Destroy = GameObject.Find(hitinfo.transform.name);
        Destroy(to_Destroy);
    }
    public void ColorRay()
    {
        Physics.Raycast(tf_Player.position, tf_Player.forward, out hitinfo, range, colorLayer);
        to_Colorit = GameObject.Find(hitinfo.transform.name);
        to_Colorit.GetComponent<Renderer>().material.color = new Color(SliderController.color.r / 255, SliderController.color.g / 255, SliderController.color.b / 255);
        PreviewObject.SetColor(to_Colorit.GetComponent<Renderer>().material, to_Colorit.transform);
    }
}
