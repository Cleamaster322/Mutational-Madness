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

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        fleshcounter.text = "" + player.flesh;
        UpdateHealthDisplay(player.health);
    }


    public void UpdateHealthDisplay(int health)
    {
        int heartDifference = health - hearts.Count;
        if (heartDifference < 0)
        {
            Destroy(hearts[hearts.Count + heartDifference]);
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
                    // Обработка ошибки, если hearts[hearts.Count - 1] равно null
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
        
    }


}
