using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderPlay : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button4;
    
    void OnEnable()
    {
        button1.onClick.AddListener(() => LoadScene("test"));
        button2.onClick.AddListener(() => LoadScene("Loads"));
        button4.onClick.AddListener(() => LoadScene("MainMenu"));
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}