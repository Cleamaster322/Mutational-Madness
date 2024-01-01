using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    void Start()
    {
        button1.onClick.AddListener(() =>
        {
            SaveLoadData.SelectedSlot = 1;
            LoadScene("test");
        });
        button2.onClick.AddListener(() =>
        {
            SaveLoadData.SelectedSlot = 2;
            LoadScene("test");
        });
        button3.onClick.AddListener(() =>
        {
            SaveLoadData.SelectedSlot = 3;
            LoadScene("test");
        });
        button4.onClick.AddListener(() => LoadScene("PlayMenu"));

        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}

public static class SaveLoadData
{
    public static int SelectedSlot { get; set; }
}