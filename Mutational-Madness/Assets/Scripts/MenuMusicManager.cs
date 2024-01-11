using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    private AudioSource audioSource;
    private AudioSource gameAudioSource;
    public float musicVolume;
    public float gameVolume;
    void Awake()
    {
       
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        gameAudioSource = gameObject.AddComponent<AudioSource>();
        musicVolume = 1.0f;
        gameVolume = 1.0f;
    }

    void Start()
    {
        string path = "Assets/gamesound/ingame1slow.mp3";
        AudioClip clip = (AudioClip)AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
        audioSource.clip = clip;
        audioSource.volume = musicVolume;
        audioSource.loop = true;
        audioSource.Play();
        string pathGame = "Assets/gamesound/menu.mp3";
        AudioClip clipGame = (AudioClip)AssetDatabase.LoadAssetAtPath(pathGame, typeof(AudioClip));
        gameAudioSource.clip = clipGame;
        gameAudioSource.volume = musicVolume;
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

    public void ChangeVolume(float value)
    {
        audioSource.volume = value;
        gameAudioSource.volume = value;
    }

    public float GetVolume()
    {
        return this.musicVolume;
    }
    public void ChangeGameVolume(float value)
    {
        gameVolume = value;
    }

    public float GetGameVolume()
    {
        return this.gameVolume;
    }
}
