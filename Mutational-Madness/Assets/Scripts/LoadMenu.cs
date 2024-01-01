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
            SaveLoadData.SelectedSlot = 0;
            Debug.Log($"Selected slot: {SaveLoadData.SelectedSlot}");
            LoadScene("test");
        });
        button2.onClick.AddListener(() =>
        {
            SaveLoadData.SelectedSlot = 1;
            Debug.Log($"Selected slot: {SaveLoadData.SelectedSlot}");
            LoadScene("test");
        });
        button3.onClick.AddListener(() =>
        {
            SaveLoadData.SelectedSlot = 2;
            Debug.Log($"Selected slot: {SaveLoadData.SelectedSlot}");
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