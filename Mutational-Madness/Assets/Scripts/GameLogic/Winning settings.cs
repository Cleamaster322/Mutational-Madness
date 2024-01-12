using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Winningsettings : MonoBehaviour
{
    private Player player;
    public Image screenRenderer;
    public GameObject screen;
    private Sprite[] images;
    private AudioClip[] sounds;
    public AudioSource soundPlayer;
    public string imagesFolder = "badcats";
    public string soundsFolder = "badcats/badmeow";
    public GameObject canvas;
    private int flag = 0;
    public string goodImagesFolder = "goodcats";
    public string goodSoundsFolder = "goodcats/goodmeow";
    private Sprite[] goodImages;
    private AudioClip[] goodSounds;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        LoadImagesAndSounds();
        LoadGoodImagesAndSounds();
    }
    // Start is called before the first frame update
    void Start()
    {
        screen.SetActive(false);
        soundPlayer = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag==0 & player.health <= 0)
        {
            CongratulationsOnLosing(player);
            flag++;
        }
        else if (flag == 0 & player.flesh >= 12)
        {
            CongratulationsOnWinning(player);
            flag++;
        }
    }

    private void CongratulationsOnWinning(Player player)
    {
        canvas.SetActive(false);
        screen.SetActive(true);
        if (goodImages.Length > 0 && goodSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, goodImages.Length);
            screenRenderer.sprite = goodImages[randomIndex];
            soundPlayer.clip = goodSounds[randomIndex];
            soundPlayer.Play();
        }
    }

    private void CongratulationsOnLosing(Player player)
    {
        canvas.SetActive(false);
        screen.SetActive(true);
        if (images.Length > 0 && sounds.Length > 0)
        {
            int randomIndex = Random.Range(0, images.Length);
            screenRenderer.sprite = images[randomIndex];
            soundPlayer.clip = sounds[randomIndex];
            soundPlayer.Play();

        }
    }

    void LoadImagesAndSounds()
    {
        
        string fullImagesPath = $"{Application.dataPath}/{imagesFolder}";
        string fullSoundsPath = $"{Application.dataPath}/{soundsFolder}";
        if (!System.IO.Directory.Exists(fullImagesPath) || !System.IO.Directory.Exists(fullSoundsPath))
        {
            return;
        }

        var imageGuids = AssetDatabase.FindAssets("t:Texture2D", new string[] { $"Assets/{imagesFolder}" });
        var soundGuids = AssetDatabase.FindAssets("t:AudioClip", new string[] { $"Assets/{soundsFolder}" });

        images = new Sprite[imageGuids.Length];
        sounds = new AudioClip[soundGuids.Length];
        for (int i = 0; i < imageGuids.Length; i++)
        {
            var imagePath = AssetDatabase.GUIDToAssetPath(imageGuids[i]);
            images[i] = AssetDatabase.LoadAssetAtPath<Sprite>(imagePath);
        }
        for (int i = 0; i < soundGuids.Length; i++)
        {
            var soundPath = AssetDatabase.GUIDToAssetPath(soundGuids[i]);
            sounds[i] = AssetDatabase.LoadAssetAtPath<AudioClip>(soundPath);
        }
    }
    void LoadGoodImagesAndSounds()
    {
        string fullImagesPath = $"{Application.dataPath}/{goodImagesFolder}";
        string fullSoundsPath = $"{Application.dataPath}/{goodSoundsFolder}";
        if (!System.IO.Directory.Exists(fullImagesPath) || !System.IO.Directory.Exists(fullSoundsPath))
        {
            return;
        }

        var imageGuids = AssetDatabase.FindAssets("t:Texture2D", new string[] { $"Assets/{goodImagesFolder}" });
        var soundGuids = AssetDatabase.FindAssets("t:AudioClip", new string[] { $"Assets/{goodSoundsFolder}" });

        goodImages = new Sprite[imageGuids.Length];
        goodSounds = new AudioClip[soundGuids.Length];
        for (int i = 0; i < imageGuids.Length; i++)
        {
            var imagePath = AssetDatabase.GUIDToAssetPath(imageGuids[i]);
            goodImages[i] = AssetDatabase.LoadAssetAtPath<Sprite>(imagePath);
        }
        for (int i = 0; i < soundGuids.Length; i++)
        {
            var soundPath = AssetDatabase.GUIDToAssetPath(soundGuids[i]);
            goodSounds[i] = AssetDatabase.LoadAssetAtPath<AudioClip>(soundPath);
        }
    }

}
