using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class UIStackManager : MonoBehaviour
{
    public Stack<GameObject> uiStack = new Stack<GameObject>();

    public Button[] buttons;
    public GameObject[] popupUIs;
    void Start()
    {
        buttons[0].onClick.AddListener(popupOn1);
        buttons[1].onClick.AddListener(popupOn2);
        buttons[2].onClick.AddListener(popupOn3);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject currUI = uiStack.Pop();
            currUI.SetActive(false);
        }
    }
    void popupOn1()
    {
        popupUIs[0].SetActive(true);
        uiStack.Push(popupUIs[0]);
    }
    void popupOn2()
    {
        popupUIs[1].SetActive(true);
        uiStack.Push(popupUIs[1]);
    }
    void popupOn3()
    {
        popupUIs[2].SetActive(true);
        uiStack.Push(popupUIs[2]);
    }
}
