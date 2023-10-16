using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WindowManager : MonoBehaviour
{
    public List<GameObject> windows;
    public List<Button> buttons;

    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => ShowWindow(index));
        }
    }

    void ShowWindow(int index)
    {
        for (int i = 0; i < windows.Count; i++)
        {
            windows[i].SetActive(i == index);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}