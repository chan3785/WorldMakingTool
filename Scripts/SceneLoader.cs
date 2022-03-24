using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Button[] worldsButton;
    Color[] buttonColor;
    public bool isSelected;
    string worldName;
    void Start()
    {
        for (int i = 0; i < worldsButton.Length; i++)
        {
            buttonColor[i] = worldsButton[i].GetComponent<Color>();
        }
    }

    void Update()
    {
        NextButtonControl();
    }

    void NextButtonControl()
    {
        if (isSelected)
        {
            this.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
        }
    }
    #region Select Method
    public void Selected()
    {
        isSelected = true;
    }
    public void notSelected()
    {
        isSelected = false;
    }
    #endregion
    public void ClickEvent()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        worldName = clickedButton.GetComponentInChildren<Text>().text;
    }
    public void ChangingEvent()
    {
        Invoke("ChangeScene", 0.7f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(worldName);
    }
}
