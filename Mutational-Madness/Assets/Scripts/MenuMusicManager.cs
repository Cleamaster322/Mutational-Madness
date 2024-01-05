using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    private AudioSource audioSource;

    void Awake()
    {
       
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        string path = "Assets/gamesound/menu.mp3";
        AudioClip clip = (AudioClip)AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
        audioSource.clip = clip;
        audioSource.volume = 1f;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void PlayMusic()
    {
        audioSource.Play();
    }
}
