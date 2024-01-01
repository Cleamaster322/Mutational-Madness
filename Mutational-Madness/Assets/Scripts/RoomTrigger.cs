using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivationZone : MonoBehaviour
{
    public GameObject[] enemies;
    public float fallSpeed = 1f;
    private int flag;
    public int room;
    private Player player;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        foreach (var enemy in enemies)
        {
            enemy.SetActive(false);
            flag = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (flag == 0 & other.gameObject.CompareTag("Player"))
        {
            flag = 1;
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