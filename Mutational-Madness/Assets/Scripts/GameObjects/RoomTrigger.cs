using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ActivationZone : MonoBehaviour
{
    //Triggers by the entries of the rooms, each has list of monsters
    public GameObject[] enemies;
    public float fallSpeed = 1f;
    private int flag;
    public int room;
    private Player player;
    public AudioClip roomEnteringSound; 
    public AudioSource audioSource;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        flag = 0;
        foreach (var enemy in enemies)
        {
            enemy.SetActive(false);       
        }

        audioSource = gameObject.AddComponent<AudioSource>(); 
        roomEnteringSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/room_entering.wav");
        audioSource.volume = MusicManager.instance.GetGameVolume()/5;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (flag == 0 & other.gameObject.CompareTag("Player"))
        {
            flag = 1;
            audioSource.PlayOneShot(roomEnteringSound);
            foreach (var enemy in enemies)
            {              
                enemy.SetActive(true);        
            }
            if (room == 1)
            {
                player.weapon = 1;
            }
        }
    }

    public ActivationZoneMemento SaveState()
    {
        ActivationZoneMemento memento = new ActivationZoneMemento
        {
            enemiesActive = new bool[enemies.Length],
            flag = flag
        };

        for (int i = 0; i < enemies.Length; i++)
        {
            memento.enemiesActive[i] = enemies[i].activeSelf;
        }

        return memento;
    }

    public void RestoreState(ActivationZoneMemento memento)
    {
        flag = memento.flag;

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(memento.enemiesActive[i]);
        }
    }

}

[System.Serializable]
public class ActivationZoneMemento
{
    public bool[] enemiesActive;
    public int flag;
}