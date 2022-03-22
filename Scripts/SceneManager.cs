using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Button[] worldsButton;
    public bool isSelected;
    void Start()
    {
    }

    void Update()
    {
        EnableGoNext();
    }

    void EnableGoNext()
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

    public void Selected()
    {
        isSelected = true;
    }
}
