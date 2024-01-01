using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text fleshcounter;
    
    private Player player;
    public List<GameObject> hearts;
    public GameObject heartPrefab;
    public List<Enemy> enemies;
    public List<ActivationZone> activationZones;
    private Caretaker caretaker = new Caretaker();
    public static Manager Instance;

    void Awake()
    {
        Instance = this;
        player = FindObjectOfType<Player>();
    }

    
    void Start()
   {
       SceneManager.sceneLoaded += OnSceneLoaded;
       fleshcounter.text = "" + player.flesh;
       UpdateHealthDisplay(player.health);
   }

   void OnSceneLoaded(Scene scene, LoadSceneMode mode)
   {
       if (scene.name == "test")
       {
           LoadGame();
       }
   }


    public void UpdateHealthDisplay(int health)
    {
        int heartDifference = health - hearts.Count;
        if (health <= 0)
        {
            SceneManager.LoadScene("PlayMenu");
        }
        else if (heartDifference < 0)
        {
            for (int i = 1; i <= heartDifference*(-1); i++)
            {
                Destroy(hearts[hearts.Count - i]);
            }
        }
        else if (heartDifference > 0)
        {
            for (int i = 0; i < heartDifference; i++)
            {
                if (hearts[hearts.Count - 1] != null)
                {
                    Vector3 newPosition = hearts[hearts.Count - 1].transform.position + new Vector3(50, 0, 0);
                    hearts.Add(Instantiate(heartPrefab, newPosition, hearts[hearts.Count - 1].transform.rotation));
                }
                else
                {
                    
                }
            }
        }
    }


    void Update()
    {
        fleshcounter.text = "" + player.flesh;
        
        UpdateHealthDisplay(player.health);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.weapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.weapon = 2;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadGame();
        }

    }
    void SaveGame()
    {
        Memento memento = new Memento
        {
            playerState = player.SaveState(),
            enemyStates = new List<EnemyMemento>(),
            activationZoneStates = new List<ActivationZoneMemento>()
        };

        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                memento.enemyStates.Add(enemy.SaveState());
            }
        }

        foreach (var activationZone in activationZones)
        {
            memento.activationZoneStates.Add(activationZone.SaveState());
        }

        caretaker.SaveMemento(memento, SaveLoadData.SelectedSlot);
    }

    public void LoadGame()
    {
        Debug.Log($"Loading game from slot: {SaveLoadData.SelectedSlot}");

        Memento memento = caretaker.LoadMemento(SaveLoadData.SelectedSlot);

        if (memento != null)
        {
            player.RestoreState(memento.playerState);

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].RestoreState(memento.enemyStates[i]);
                }
            }

            for (int i = 0; i < activationZones.Count; i++)
            {
                activationZones[i].RestoreState(memento.activationZoneStates[i]);
            }
        }
        else
        {
            Debug.LogError("No saved game found in the selected slot.");
        }
    }


}





