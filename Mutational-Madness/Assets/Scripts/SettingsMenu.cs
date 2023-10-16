using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;


    void OnEnable()
    {
        button1.onClick.AddListener(() => LoadScene(""));
        button2.onClick.AddListener(() => LoadScene(""));
        button3.onClick.AddListener(() => LoadScene(""));
        button4.onClick.AddListener(() => LoadScene(""));
        button5.onClick.AddListener(() => LoadScene("MainMenu"));

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
