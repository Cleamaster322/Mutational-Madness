using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    private AudioSource audioSource;
    private AudioSource gameAudioSource;
    void Awake()
    {
       
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        gameAudioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        string path = "Assets/gamesound/ingame1slow.mp3";
        AudioClip clip = (AudioClip)AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
        audioSource.clip = clip;
        audioSource.volume = 1f;
        audioSource.loop = true;
        audioSource.Play();
        string pathGame = "Assets/gamesound/menu.mp3";
        AudioClip clipGame = (AudioClip)AssetDatabase.LoadAssetAtPath(pathGame, typeof(AudioClip));
        gameAudioSource.clip = clipGame;
        gameAudioSource.volume = 0.5f;
        gameAudioSource.loop = true;
        
    }
    public void StopMusic()
    {
        audioSource.Stop();
        gameAudioSource.Play();
    }
    public void PlayMusic()
    {
        audioSource.Play();
        gameAudioSource.Stop();
    }
}
