using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    //slider's control for sound level
    public Slider volumeSlider;
    public Slider ingamevolumeSlider;

    void Start()
    {
        volumeSlider.value = MusicManager.instance.GetVolume();
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        ingamevolumeSlider.value = MusicManager.instance.GetGameVolume();
        ingamevolumeSlider.onValueChanged.AddListener(ChangeGameVolume);
    }

    void ChangeVolume(float value)
    {
        MusicManager.instance.ChangeVolume(value);
    }
    void ChangeGameVolume(float value)
    {
        MusicManager.instance.ChangeGameVolume(value);
    }
}

