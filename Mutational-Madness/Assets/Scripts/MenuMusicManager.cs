using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    private AudioSource audioSource;
    private AudioSource gameAudioSource;
    public float volume;
    void Awake()
    {
       
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        gameAudioSource = gameObject.AddComponent<AudioSource>();
        volume = 1.0f;
    }

    void Start()
    {
        string path = "Assets/gamesound/ingame1slow.mp3";
        AudioClip clip = (AudioClip)AssetDatabase.LoadAssetAtPath(path, typeof(AudioClip));
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = true;
        audioSource.Play();
        string pathGame = "Assets/gamesound/menu.mp3";
        AudioClip clipGame = (AudioClip)AssetDatabase.LoadAssetAtPath(pathGame, typeof(AudioClip));
        gameAudioSource.clip = clipGame;
        gameAudioSource.volume = volume;
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
        return this.volume;
    }
}
