using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;


    void Start()
    {
        volumeSlider.value = MusicManager.instance.GetVolume();
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float value)
    {
        MusicManager.instance.ChangeVolume(value);
    }
}

