using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public GameObject info;
    public GameObject PanSan;
    

    private void Start()
    {
        info.SetActive(false);
        PanSan.SetActive(false);
    }

    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => LoadScene("PlayMenu"));
        button2.onClick.AddListener(() => LoadScene("SettingsMenu"));
        button3.onClick.AddListener(() => Application.Quit());
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

